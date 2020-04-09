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
    // connecting my interface to my service
    public class AmenitiesService : IAmenitiesManager
    {
        private AsyncDbContext _context;
        public AmenitiesService(AsyncDbContext context)
        {
            _context = context;
        }

        public async Task<List<AmenityDTO>> GetAll()
        {
            var allAmenities = await _context.Amenities.ToListAsync();
            List<AmenityDTO> allDTOs = new List<AmenityDTO>();

            foreach (var item in allAmenities)
            {
                allDTOs.Add(ConvertToDTO(item));
            }

            return allDTOs;
        }

        public async Task<AmenityDTO> GetById(int id)
        {
            Amenities amenity = await _context.Amenities.FindAsync(id);

            return ConvertToDTO(amenity);
        }

        private AmenityDTO ConvertToDTO(Amenities amenity)
        {
            AmenityDTO adto = new AmenityDTO()
            {
                Name = amenity.Name,
                ID = amenity.ID
            };

            return adto;
        }

        private Amenities ConvertFromDTO(AmenityDTO dto)
        {
            return null;
        }
    }
}
