using Interfacesd10.Classes;
using Interfacesd10.Interfaces;
using System;

namespace Interfacesd10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Unicorn unicorn = new Unicorn();

        }

        static void TestOutInterfaces()
        {
            // This exhibits polymorphism because
            // we are able to group together types
            ISpeak[] speaks = new ISpeak[2];

            ISpeak speak = new Smurf();

            // unicorn implements ispeak...so we can use it
            Unicorn uni = new Unicorn();
            uni.Color = "pink";
            uni.Name = "Magical Unicorn";
            uni.CreateCutieMark();

            Smurf smurf = new Smurf();
            smurf.Name = "Smurfy";

            speaks[0] = uni;
            speaks[1] = smurf;

            for (int i = 0; i < speaks.Length; i++)
            {
                speaks[i].SayHello();
            }

            MagicalCreature[] mc = new MagicalCreature[2];

            Dragon dragon = new Dragon();

            mc[0] = uni;
            mc[1] = dragon;

            for (int i = 0; i < mc.Length; i++)
            {
                if (mc[i] is ISpeak)
                {
                    // put that obj in another array
                    // save it into the db
                }
            }


        }

        public void FlyHigh(IFly bird)
        {
            // wingspan does not exist in the ifly interface
         //   var span = bird.Wingspan;
        }
        static void PublicSpeaking(ISpeak speaker)
        {
            speaker.SayHello();
        }
    }
}
