using InterfacesReview.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesReview.Classes
{
    class Boat : IDrivable
    {
        public void Accelerate()
        {
            Console.WriteLine("Vroom Vroom!");
        }

        public void Brake()
        {
            Console.WriteLine("SLOW DOWN!");
        }

        public void Start(IDrive driver)
        {
            Console.WriteLine("START!");
        }

        public void Stop()
        {
            Console.WriteLine("STOP!");
        }
    }
}
