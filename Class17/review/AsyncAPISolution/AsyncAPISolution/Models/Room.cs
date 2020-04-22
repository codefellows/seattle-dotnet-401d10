using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAPISolution.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public RoomType Layout { get; set; }
    }

    public enum RoomType
    {
        Studio = 0,
        OneBedroom = 1,
        TwoBedroom = 2
    }
}
