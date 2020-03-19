using System;
using System.IO;

namespace d10Class03Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // WriteToAFile();
            // ReadAFile();
            // ReadAllLines();
            // FileAppendText();
            // ReadFile();

            DeleteItem("One Fish, Two Fish, Red Fish, Blue Fish");

            //UpdateFile();
            // DeleteAFile();
            //  PracticeUsingSplit();
        }

        // Write to a File
        static void WriteToAFile(string[] contents)
        {
            // Defined a path to our file
            // change our path to point to a specific location
            string potato = "../../../amanda.txt";
            // Wrote to the file specific text in it's location
            File.WriteAllLines(potato, contents);
            //File.WriteAllText(potato, "The time has come, the walrus said....");

        }

        static void DeleteItem(string textToRemove)
        {
            // Read in the file as an array
            string[] words = ReadAllLines();


            int occurances = 0;
            // Go through the whole array and find the number of times it exists
            // then minus that number from the length
            // .Contains()
            // .ToUpper()
            // .ToLower()
            // . Split(,)

            for (int i = 0; i < words.Length; i++)
            {
                if(words[i] == textToRemove)
                {
                    occurances++;
                }
            }

            // new array minus the index we want to remove. 
            string[] newWords = new string[words.Length - occurances];

            int fakeIndex = 0;
            // find the individual index you want to remove
            // Go through every index in the array 
            // and evaluate if it is the workd in question
            for (int i = 0; i < words.Length; i++)
            {
                // If it is not the word in question, then, we are going to add the word
                // to the new array AND incrament our fake counter to keep track of our indexes in our new array. 
                if(words[i] != textToRemove)
                {
                    // put it in the new array if the word is not what we are looking for
                    newWords[fakeIndex] = words[i];
                    fakeIndex++;
                }
            }

            WriteToAFile(newWords);

            // "remove the item" by ignoring it
            // overwrite the file with the new contents.


        }

        // Read a file
        static void ReadAFile()
        {
            Console.WriteLine("READING A FILE:");
            Console.WriteLine("=============");
            string potato = "../../../amanda.txt";

            string myFile = File.ReadAllText(potato);
            Console.WriteLine(myFile);
        }

        static string[] ReadAllLines()
        {
            string potato = "../../../amanda.txt";
            string[] myText = File.ReadAllLines(potato);
            return myText;

        }

        static void FileAppendText(string[] contents)
        {
            string potato = "../../../amanda.txt";

            //// way 1
            //string[] myWords = new string[4] { "value 1", "value 2", "value 3", "value 4"};
            //myWords[0] = "The cat in the hat";
            //myWords[1] = "Green Eggs and Ham";

            // alternative way to declare an array
            //string[] words =
            //{
            //    "The Cat in the Hat",
            //    "Green Eggs and Ham",
            //    "One Fish, Two Fish, Red Fish, Blue Fish",
            //    "Horton hears a Who"
            //};

            File.AppendAllLines(potato, contents);
        }

        static void ReadFile()
        {
            string potato = "../../../amanda.txt";

            // alternative way to read a text file
            try
            {
                // using a stream/ opening a connection
                // Connecting using a stream to our file and opening it up
                using (StreamReader sr = File.OpenText(potato))
                {
                    string text = "";
                    // read every line and output it to hte console
                    // reading will "stop" once there are no more text lines
                    while ((text = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(text);
                    }
                }
            }
            catch (FileNotFoundException e)
            {

                Console.WriteLine("Your file is not available");
            }
            finally
            {
                Console.WriteLine("process complete");
            }
        }
        // Update a file
        static void UpdateFile()
        {
            string potato = "../../../amanda.txt";

            // Add the numbers 0 - 4 in the text
            using (StreamWriter sw = File.AppendText(potato))
            {
                for (int i = 0; i < 5; i++)
                {
                    sw.WriteLine(i);
                }
            }
        }
        // Delete a file

        static void DeleteAFile()
        {
            string potato = "../../../amanda.txt";

            File.Delete(potato);

        }

        static void PracticeUsingSplit()
        {
            // list of all possible deliminaters or seperators
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string text = "one\ttwo three:four,five six seven";

            //string words = text.Split(',');
            string[] words = text.Split(delimiterChars);

            // for each item in the array, do something
            foreach (string item in words)
            {
                Console.WriteLine(item);
            }

        }
    }
}
