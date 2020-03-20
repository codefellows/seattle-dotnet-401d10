using System;
using System.Collections.Generic;
using System.Text;

namespace d10Class04Demo.Classes
{
    class Library
    {

        // Property is declared LIKE A FIELD, but it has what we call "getters" and "setters"
        // "get" a value and "set" a value
        // c# 6.0 - "Auto Implemented Properties
        public string Address { get; set; } // backing store exists...background and invisible

        // this is the manual way of creating properties. 
        private string name; // the name field...also called "backing store
        public string Name
        {
            get
            {
                return name != null ? name : "NA";
            }
            set
            {
                if (name.Contains("Josie"))
                {
                    throw new Exception("Josie is already taken!");
                }
                name = value;
            }
        }

        private int month = 12; // backing store
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if ((value > 0) && (value < 13))
                {
                    month = value; 
                }
            }
        }

        // Bad Practice
        private int number;
        public int Number
        {
            get
            {
                return number++;
            }
        }


        // this is NOT a method.
        // this a constructor.
        // this is your empty ctor. 
        // this is what is given to you behind the scenes
        public Library(string libName)
        {
            name = libName;
        }
        // Class is going to contain methods, behaviors, and properties that define this class. 

        // Methods

        /// <summary>
        /// Method in our class that is called MyLibrary that will output to the console the word we send it.
        /// </summary>
        /// <param name="word">a random phrase or saying</param>
        /// // This method is called an "instance" method
        public void MyLibrary(string word)
        {
            Console.WriteLine($"This is our word: {word}");
        }

        public static void Open()
        {
            Console.WriteLine("WE ARE OPEN!!");
        }
    }
}
