using InterfacesReview.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesReview.Classes
{
    // our Car implements the Drivable interface
    // "Our car is drivable"
    // " we can use our car to "drive"
    class Car : IDrivable
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MaxTankSize { get; set; } = 10;
        public bool HasSunRoof { get; set; }

        public void Accelerate()
        {
            Console.WriteLine("Green means go!");
        }

        public void Brake()
        {
            Console.WriteLine("You are going wayy to fast! Slow down!");
        }

        public void FillGas(int currentGasLevel)
        {
            while(currentGasLevel < MaxTankSize)
            {
                currentGasLevel++;
            }
        }

        public void OpenSunroof()
        {
            if (HasSunRoof)
            {
                Console.WriteLine("open!");
            }
            else
            {
                Console.WriteLine("You must upgrade!");
            }
        }

        public void Start(IDrive driver)
        {
            Console.WriteLine("Telpathy can start my car!");
        }

        public void Stop()
        {
            Console.WriteLine("Hit the brake! Stop!!");
        }

    }
}
