using System;
using System.Collections.Generic;
using System.Text;

namespace Interfacesd10.Interfaces
{
    interface IFly
    {
        // only going to contain Method Signatures of what is required for that action to be completed

        public int TopSpeed { get; set; }

        void TakeOff();

        bool Land(int speed);

        void LeapOffAllThings();
    }
}
