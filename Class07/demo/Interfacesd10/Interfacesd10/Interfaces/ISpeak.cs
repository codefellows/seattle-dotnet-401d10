using System;
using System.Collections.Generic;
using System.Text;

namespace Interfacesd10.Interfaces
{
    interface ISpeak
    {
        public string VoiceTone { get; set; }
        public string SayHello();
    }
}
