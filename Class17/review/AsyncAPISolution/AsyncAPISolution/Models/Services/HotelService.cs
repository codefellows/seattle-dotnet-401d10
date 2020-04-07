using AsyncAPISolution.Data;
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

        public async Task<List<Hotel>> GetAllhotels() => await _context.Hotels.ToListAsync();

        public async Task<Hotel> GetHotelByID(int hotelId)
        {
            Hotel hotel = await _context.Hotels.FindAsync(hotelId);
            return hotel;
        }

        public async Task RemoveHotel(int hotelId)
        {
            Hotel hotel = await GetHotelByID(hotelId);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateHotel(int hotelId, Hotel hotel)
        {
            // set that hotel equal to the one i passed in. 
            _context.Entry(hotel).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            // save changes
        }
    }
}
