using Interfacesd10.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfacesd10.Classes
{
    class MagicalCreature : IFly
    {
        public int Wingspan { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TopSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DoMagicalThing()
        {
            Console.WriteLine("MAGIC!");
        }

        public bool Land(int speed)
        {
            throw new NotImplementedException();
        }

        public void LeapOffAllThings()
        {
            throw new NotImplementedException();
        }

        public void TakeOff()
        {
            throw new NotImplementedException();
        }
    }
}
