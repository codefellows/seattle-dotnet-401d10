using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQDemoD10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string path = "../../../data.json";
            ReadJson(path);
        }

        // Read in our File
        public static void ReadJson(string path)
        {
            // read in our file
            string text = "";
            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            //Serialize = Convert from C# -> JSON
            // Deserialize = Convert from Json -> C#
            // conversion of the JSon
            RootObject myObject = JsonConvert.DeserializeObject<RootObject>(text);
            AskQuestions(myObject);

        }


        static void AskQuestions(RootObject root)
        {
            // queries
            var query = from feature in root.features
                        select feature.properties.neighborhood;
            var counter = 0;
            foreach (var item in query)
            {
                Console.WriteLine(item);
                counter++;

            }
            Console.WriteLine($"Neighborhoods: {counter}");

            Console.WriteLine("============= Question 2 ==================");

            // Question2: filter out each of the neighborhoods that do not have any names

            var query2 = from neighborhood in query
                         where neighborhood != ""
                         select neighborhood;
            counter = 0;
            foreach (var item in query2)
            {
                Console.WriteLine(item);
                counter++;
            }

            Console.WriteLine($"Neighborhoods: {counter}");


            Console.WriteLine("========== Question 3 ============");

            // Question 3: Remove all the duplicates
            var filtered = query2.Distinct();
            counter = 0;

            foreach (var item in filtered)
            {
                Console.WriteLine(item);
                counter++;
            }

            Console.WriteLine($"Neighborhoods: {counter}");

            // rewrite all 3 queries to just one

            var query4 = root.features.Where(hood => hood.properties.neighborhood.Length > 0)
                                       .GroupBy(x => x.properties.neighborhood)
                                        .Select(x => x.First());

            Console.WriteLine("========== Question 4 ============");


            counter = 0;
            foreach (var item in query4)
            {
                Console.WriteLine(item.properties.neighborhood);
                counter++;
            }

            Console.WriteLine($"Neighborhoods: {counter}");


            // 5. Rewrite at least one of these questions using only a linq method call

            var query5 = query.Where(p => p != "");

            counter = 0;
            foreach (var item in query5)
            {
                Console.WriteLine(item);
                counter++;
            }

            Console.WriteLine($"Neighborhoods: {counter}");


        }


    }


    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Properties
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address { get; set; }
        public string borough { get; set; }
        public string neighborhood { get; set; }
        public string county { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class RootObject
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
}
