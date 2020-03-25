using Interfacesd10.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfacesd10.Classes
{
    class Smurf : ISpeak
    {
        public string Name { get; set; }
        public string VoiceTone { get ; set; }

        public string SayHello()
        {
            return "Smurfity smurf smurf smurf";
        }
    }
}
