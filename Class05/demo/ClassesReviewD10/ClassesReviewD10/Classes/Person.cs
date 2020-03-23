using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesReviewD10.Classes
{
    class Person
    {
        // Classes are types(ish) and they can contain methods, properties, and (private) fields and some kind of ctor, regardless if we make it ourselves. 

        // Attributes and behaviors of the class

        // when we instantiate classes...we make objects. 
        // object is an instance of a class. 

        // Strings are reference types 
        // by default - Their values are null
        // if we call somethign with a null value...potential for an exception. 
        public string Name { get; set; } = "N/A";
        public int Age { get; set; }
        public int Height { get; set; }
        public int NumberOfCats { get; set; }

        private int _number;

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }

        public Person(string name)
        {
            Name = name;
        }

        public Person()
        {
            // b/c we have a prop above with a default value, this is no longer needed
            // Name = "N/A";
        }


        public void DrinkCoffee()
        {
            Console.WriteLine($"{Name} is drinking coffee!");
        }

        /// <summary>
        /// Play out side with no restrictions
        /// </summary>
        public void PlayOutside()
        {
            Console.WriteLine("Go outside!");
        }

        /// <summary>
        /// Play outside with a location
        /// </summary>
        /// <param name="location"></param>
        public void PlayOutside(string location)
        {
            Console.WriteLine("Go to the pllace of location");
        }

        /// <summary>
        /// Implement a curfew for the player
        /// </summary>
        /// <param name="curfew"></param>
        public void PlayOutside(bool curfew)
        {
            // add logic here
        }



    }
}
