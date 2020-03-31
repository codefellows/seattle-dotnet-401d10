using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_TimePerson.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }


        public static List<TimePerson> GetPersons(int begYear, int endYear)
        {
            // create a list of Time persons (instantiate a new list)
            // get the path of your timeperson.csv file
            // getting the path is not as simple as ../../../ have to use 
            // the Path or Environment class

            // once you get the file path, 
            // read all the lines and save it into an array of strings
            // traverse through the strings for each line item
            // remember CSV is delimited by commas. 

            // use LINQ to filter out with the years that you brought in against your list of persons

            //return your list of persons

            return null;
        }
    }
}
