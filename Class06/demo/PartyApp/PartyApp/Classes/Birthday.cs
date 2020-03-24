using System;
using System.Collections.Generic;
using System.Text;

namespace PartyApp.Classes
{
    // to show inheritance you must have
    // NAME OF DERIVED CLASS : NAME OF BASE CLASS
    abstract class Birthday : Party
    {
        public string CakeFlavor { get; set; }
        public virtual bool HasClown { get; set; } = true;
        public sealed override int Budget { get; set; } = 500;

        public virtual string PlayGames()
        {
            return "We are playing musical chairs";
        }

        public override void Setup()
        {
            Console.WriteLine("I am setting up");
        }
    }
}
