using AsyncAPISolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAPISolution.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        Task<AmenityDTO> GetById(int id);

        Task<List<AmenityDTO>> GetAll();
    }
}
