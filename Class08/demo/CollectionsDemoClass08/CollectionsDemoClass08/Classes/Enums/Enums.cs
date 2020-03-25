using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsDemoClass08.Classes.Enums
{
    // value types for enums are ints
    enum Day
    {
        // by default the values in a enum start at 0
        Sunday, // equal to 0
        Monday, // equal to 1
        Tuesday, // equal to 2
        Wednesday = 100, // wed = 5
        Thursday = 101,
        Friday = 102,
        Saturday = 7// 103
    }

    enum MonthsOfYear : byte
    {
        Jan,
        Feb,
        March,
        Apri
    }
}
