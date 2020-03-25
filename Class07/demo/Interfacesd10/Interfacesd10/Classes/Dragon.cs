using Interfacesd10.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfacesd10.Classes
{
    class Dragon : MagicalCreature
    {

        public void HoardGold()
        {
            Console.WriteLine("It's all mine!");
        }

        public void BreathFire(int angerLevel)
        {
            if(angerLevel < 10)
            {
                Console.WriteLine("Only a little fire...");
            }
            else
            {
                Console.WriteLine("BURN IT ALL WITH FIRE!");
            }
        }

    }
}
