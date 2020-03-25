using InterfacesReview.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesReview.Classes
{
    class Person : IDrive
    {
        public string Name { get; set; }
        public string StateLicense { get; set; }
        private int _age;
        public int MinAge
        {
            get
            {
                return _age;
            }
            set
            {
                if(value >= 16)
                {
                    _age = value;
                }
                else
                {
                    throw new Exception("You are not old enough");
                }
            }
        }

        public void Walk()
        {
            Console.WriteLine($"{Name} person is walking");
        }

        public void DrinkCoffee()
        {
            Console.WriteLine("I miss Starbucks!");
        }
    }
}
