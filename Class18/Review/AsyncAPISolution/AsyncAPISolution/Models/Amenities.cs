using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAPISolution.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        public string Name { get; set; }

       public List<RoomAmenities> RoomAmenities { get; set; }
    }
}
