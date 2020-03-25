using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesReview.Interfaces
{
    interface IDrivable
    {
        void Start(IDrive driver);
        void Stop();
        void Brake();
        void Accelerate();
    }
}
