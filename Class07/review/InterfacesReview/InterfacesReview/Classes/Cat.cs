using InterfacesReview.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesReview.Classes
{
    class Cat : IDrive
    {
        public string StateLicense { get; set; } = "ND";
        public int MinAge { get; set; } = 9;

        public void Meow()
        {
            Console.WriteLine("Meow Meow Meow");
        }
    }
}
