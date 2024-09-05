using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.DTO.School;
using WebApi.DTO.Transport;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransportController : ControllerBase
    {
        private readonly SchoolContext _schoolContext;

        public TransportController(SchoolContext context)
        {
            _schoolContext = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusByID(int id)
        {
            var bus = await _schoolContext.Transports
                .Include(s => s.School)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (bus == null)
            {
                return NotFound();
            }

            var busDto = new SingleBusDetailsDTO
            {
                BusNumber = bus.BusNumber,
                School = new SchoolDTO
                {
                    Id = bus.School.Id,
                    Name = bus.School.Name,
                    Location=bus.School.Location
                },
            };
            return Ok(busDto);
        }

    }
}