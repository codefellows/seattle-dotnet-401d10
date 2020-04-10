using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoD10BasicMVC.Models.Interfaces
{
    public interface IHotelManager
    {
        Task<List<Hotel>> GetAllHotels();
        Task GetHotelByID();
    }
}
