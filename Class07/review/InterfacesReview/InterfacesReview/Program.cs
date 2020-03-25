using InterfacesReview.Classes;
using InterfacesReview.Interfaces;
using System;

namespace InterfacesReview
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // make a call to my DB to collect ALL drivers in my system
            IDrive[] drivers = new IDrive[4];

            Person person = new Person() { Name = "Josie", MinAge = 16, StateLicense = "WA" };

            Cat cat = new Cat() { StateLicense = "CA", MinAge = 18 };

            Cat kitty = new Cat() { MinAge = 13, StateLicense = "ND" };

            Person person1 = new Person() { Name = "Fred", MinAge = 25, StateLicense = "AK" };

            drivers[0] = person;
            drivers[1] = kitty;
            drivers[2] = cat;
            drivers[3] = person1;

            for (int i = 0; i < drivers.Length; i++)
            {
                var driver = drivers[i];

                if(driver is Person)
                {
                    // casting 
                    var p = (Person)driver;
                    p.Walk();
                } else if (driver is Cat)
                {
                    var kat = (Cat)driver;
                    kat.Meow();
                }

                ShowDriverCredentials(drivers[i]);
                
            }


        }

        // This method does not care WHO the drivre is or WHAT is being driven...as long as the min requiremetns for each interface are met. 
        static void DriveTheCar(IDrivable vehicle, IDrive driver)
        {
            vehicle.Start(driver);

        }

        static void ShowDriverCredentials(IDrive driver)
        {
            Console.WriteLine($"My license is from {driver.StateLicense}");
            Console.WriteLine($"i am at least {driver.MinAge}");
            Console.WriteLine("===============================");
            Console.WriteLine();

        }
    }
}
