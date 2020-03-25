using Interfacesd10.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfacesd10.Classes
{
    // To implement an interface, you do 
    // the same thing that as inheritance
    // except you specify the interface. 
    // the : symbolizes both inheritance and 
    // implementation
    class Unicorn : MagicalCreature, ISpeak
    {
        public string Name { get; set; }
        public string Color { get; set; }
        /// <summary>
        /// Miles per hour of top speed
        /// </summary>
        public string VoiceTone { get; set ; }

        public void CreateCutieMark()
        {
            Console.WriteLine("You did something that earned you your cutie mar!!");
        }

        public new bool Land(int speed)
        {
            if(speed > 100)
                Console.WriteLine("SLOW DOWN");
            else
                Console.WriteLine("YOU ARE SAFE TO LAND");

            return true;
        }

        public string SayHello()
        {
            return "Friendship is magic";
        }
    }
}
