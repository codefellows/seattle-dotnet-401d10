using System;
using System.Collections.Generic;
using System.Text;

namespace PartyApp.Classes
{
    abstract class Party
    {
        public int NumberOfGuests { get; set; }
        public string Location { get; set; }
        public virtual int Budget { get; set; } = 10000;
        public string Menu { get; set; }
        public DateTime Time { get; set; }

        // abstract methods only contain the method signature
        public abstract void Setup();

        public virtual int PricePerHead(int number)
        {
            if(NumberOfGuests < 10)
            {
                return 100;
            }

            return number * 10;
        }

        public void TearDown()
        {

        }

        public void GiveSpeech()
        {

        }
    }
}
