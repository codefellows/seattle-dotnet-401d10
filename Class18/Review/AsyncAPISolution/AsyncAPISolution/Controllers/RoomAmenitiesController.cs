using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncAPISolution.Data;
using AsyncAPISolution.Models;

namespace AsyncAPISolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAmenitiesController : ControllerBase
    {
        private readonly AsyncDbContext _context;

        public RoomAmenitiesController(AsyncDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomAmenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomAmenities>>> GetRoomAmenities()
        {
            return await _context.RoomAmenities.ToListAsync();
        }

        // GET: api/RoomAmenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomAmenities>> GetRoomAmenities(int id)
        {
            var roomAmenities = await _context.RoomAmenities.FindAsync(id);

            if (roomAmenities == null)
            {
                return NotFound();
            }

            return roomAmenities;
        }

        // PUT: api/RoomAmenities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomAmenities(int id, RoomAmenities roomAmenities)
        {
            if (id != roomAmenities.AmenitiesID)
            {
                return BadRequest();
            }

            _context.Entry(roomAmenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomAmenitiesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RoomAmenities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RoomAmenities>> PostRoomAmenities(RoomAmenities roomAmenities)
        {
            _context.RoomAmenities.Add(roomAmenities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomAmenitiesExists(roomAmenities.AmenitiesID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomAmenities", new { id = roomAmenities.AmenitiesID }, roomAmenities);
        }

        // DELETE: api/RoomAmenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomAmenities>> DeleteRoomAmenities(int id)
        {
            var roomAmenities = await _context.RoomAmenities.FindAsync(id);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();

            return roomAmenities;
        }

        private bool RoomAmenitiesExists(int id)
        {
            return _context.RoomAmenities.Any(e => e.AmenitiesID == id);
        }
    }
}
