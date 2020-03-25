using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesReview.Interfaces
{
    // the "min job requirements are to make sure that we have these methods present in our class
    interface IDrive
    {
        public string StateLicense { get; set; }

        public int MinAge { get; set; }
    }
}
