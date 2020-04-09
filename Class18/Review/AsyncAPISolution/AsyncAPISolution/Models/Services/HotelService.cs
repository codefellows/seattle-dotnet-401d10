using AsyncAPISolution.Data;
using AsyncAPISolution.DTOs;
using AsyncAPISolution.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAPISolution.Models.Services
{
    public class HotelService : IHotelManager
    {
        private AsyncDbContext _context;

        public HotelService(AsyncDbContext context)
        {
            _context = context;
        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            // Add the newly created hotel to our database
            _context.Hotels.Add(hotel);
            // save the database
            await _context.SaveChangesAsync();

            return hotel;
        }

        public async Task<List<Hotel>> GetAllhotels()
        {
            return _context.Hotels.ToList();

        }

        public async Task<HotelDTO> GetHotelByID(int hotelId)
        {
            Hotel hotel = new Hotel();
            HotelDTO hoteldto = new HotelDTO();
            hotel = _context.Hotels.Find(hotelId);

            hoteldto.Name = hotel.Name;
            hoteldto.Phone = hotel.Phone;
            hoteldto.City = hotel.City;

            var hotelRooms = await _context.HotelRooms.Where(r => r.HotelID == hotelId)
                                                .Include(d => d.Room)
                                                .ThenInclude(x => x.RoomAmenities)
                                                .ThenInclude(a => a.Amenities)
                                                .ToListAsync();

            List<HotelRoomDTO> room = new List<HotelRoomDTO>();

            foreach (var hr in hotelRooms)
            {

                HotelRoomDTO rm = new HotelRoomDTO();
                rm.Rate = hr.Rate;
                rm.RoomNumber = hr.RoomNumber;
                RoomDTO rdto = new RoomDTO
                {
                    Layout = hr.Room.Layout.ToString(),
                    Name = hr.Room.Name,
                };

                room.Add(rm);
            }

            hoteldto.Rooms = room;

            return hoteldto;
        }



        public async Task RemoveHotel(int hotelId)
        {
            //Hotel hotel = await GetHotelByID(hotelId);
            //_context.Hotels.Remove(hotel);
            //await _context.SaveChangesAsync();

            

        }

        public async Task UpdateHotel(int hotelId, Hotel hotel)
        {
            // set that hotel equal to the one i passed in. 
            _context.Entry(hotel).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            // save changes
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int hotelID)
        {
            // Get Rooms
            var hotelrooms = await _context.HotelRooms.Where(r => r.HotelID == hotelID)
            .Include(d => d.Room)
            .ThenInclude(a => a.RoomAmenities)
            .ThenInclude(x => x.Amenities).ToListAsync();

            //List<HotelRoomDTO> hotelRooms = new List<Hotel>();
            //foreach (var room in hotelrooms)
            //{
            //    HotelRoomDTO roomDTO = await _hotelRoom.GetById(room.RoomID);
            //    hotelRooms.Add(roomDTO);
            //}

            return hotelrooms;
        }
    }
}
