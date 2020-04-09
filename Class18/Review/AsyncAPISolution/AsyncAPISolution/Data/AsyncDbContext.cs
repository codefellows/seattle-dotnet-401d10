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

            modelBuilder.Entity<Room>().HasData(
            new Room
            {
                ID = 1,
                Layout = RoomType.OneBedroom,
                Name = "Princess Suite"
            },
            new Room
            {
                ID = 2,
                Layout = RoomType.TwoBedroom,
                Name = "Queen Suite"
            }
            );

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Coffee Maker"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Mini Bar"
                }
                );

            modelBuilder.Entity<RoomAmenities>().HasData(
                 new RoomAmenities
                 {
                     RoomID = 1,
                     AmenitiesID = 1
                 },
                 new RoomAmenities
                 {
                     RoomID = 1,
                     AmenitiesID = 2
                 },
                 new RoomAmenities
                 {
                     RoomID = 2,
                     AmenitiesID = 1
                 },
                 new RoomAmenities
                 {
                     RoomID = 2,
                     AmenitiesID = 2
                 }
                );

            modelBuilder.Entity<HotelRoom>().HasData(
            new HotelRoom
            {
                HotelID = 1,
                PetFriendly = true,
                Rate = 120m,
                RoomID = 1,
                RoomNumber = 123
            },
            new HotelRoom
            {
                HotelID = 2,
                PetFriendly = false,
                Rate = 150m,
                RoomID = 1,
                RoomNumber = 220
            },
            new HotelRoom
            {
                HotelID = 1,
                PetFriendly = false,
                Rate = 75m,
                RoomID = 2,
                RoomNumber = 101
            },
            new HotelRoom
            {
                HotelID = 2,
                PetFriendly = true,
                Rate = 175m,
                RoomID = 2,
                RoomNumber = 111
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
