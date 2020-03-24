using System;
using System.Collections.Generic;
using System.Text;

namespace PartyApp.Classes
{
    class Over21 : Birthday
    {
        public string PartyTheme { get; set; }
        public override bool HasClown { get => base.HasClown; set => base.HasClown = value; }
        public override string PlayGames()
        {
            // base keyword means "pull from who initially initalized this method"
            return $"Duck Duck Goose";
        }

        // create new behavior for teardown
        public new void TearDown()
        {

        }

        public override int PricePerHead(int number)
        {
            return base.PricePerHead(number) * 2;
        }

        // abstract methods cannot live in non-abstract classes
        //public abstract string ThisIsMyAbtractMethod();
    }
}
