using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAPISolution.Models.Interfaces
{
    public interface IHotelManager
    {
        //create a hotel
        Task<Hotel> CreateHotel(Hotel hotel);
        // update a hotel
        Task UpdateHotel(int hotelId, Hotel hotel);
        // get all hotels
        Task<List<Hotel>> GetAllhotels();
        // get a single hotel
        Task<Hotel> GetHotelByID(int hotelId);
        // delete a hotel

        Task RemoveHotel(int hotelId);

        // GetAllHotelRoomsForHotel(int id)
        // GetHotelRoomForHotel(int roomNumber , int hotelId)
    }
}
