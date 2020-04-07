using AsyncAPISolution.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAPISolution.Data
{
    public class AsyncDbContext : DbContext
    {
        public AsyncDbContext(DbContextOptions<AsyncDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(hotel => new { hotel.HotelID, hotel.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(r => new { r.AmenitiesID, r.RoomID });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Amanda's Hotel",
                    City = "Seattle",
                    Phone = "123-456-8798",
                    State = "WA"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Josie's Hotel",
                    City = "Seattle",
                    Phone = "123-852-8798",
                    State = "WA"
                }
            );
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
