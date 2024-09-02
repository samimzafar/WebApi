using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.DTO;
using WebApi.DTO.School;
using WebApi.DTO.Transport;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly SchoolContext _schoolContext;

        public AdminController(SchoolContext context)
        {
            _schoolContext = context;
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] Admin newAdmin)
        {
            var existingAdmin = await _schoolContext.Admins.FirstOrDefaultAsync(a => a.Username == "admin");
            if (existingAdmin == null)
            {
                return BadRequest("Superadmin not found.");
            }

            var adminCount = await _schoolContext.Admins.CountAsync();
            if (adminCount >= 2)
            {
                return BadRequest("Only two admins are allowed.");
            }

            _schoolContext.Admins.Add(newAdmin);
            await _schoolContext.SaveChangesAsync();

            return Ok(newAdmin);
        }

        [HttpGet("schools")]
        public async Task<IActionResult> GetAllSchools()
        {
            var schools = await _schoolContext.Schools
                .Include(s => s.Transports)
                .Select(s => new GetAllSchoolsDTO
                {
                    Name = s.Name,
                    Location = s.Location,
                    Fees = s.Fees,
                    Transports = s.Transports.Select(t => new GetAllBusesDTO
                    {
                        BusID = t.Id,
                        BusNumber = t.BusNumber
                    }).ToList()
                })
                .ToListAsync();

            return Ok(schools);
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _schoolContext.Students
                .Include(s => s.School)
                .Include(s => s.Transport)
                .ToListAsync();
            return Ok(students);
        }

        [HttpPost("add-school")]
        public async Task<IActionResult> AddSchool([FromBody] AddSchoolRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            // Create a new school entity
            var school = new School
            {
                Name = request.Name,
                Location = request.Location,
                Fees = request.Fees,
                Open = request.Open
            };

            // Add the school to the context
            _schoolContext.Schools.Add(school);
            await _schoolContext.SaveChangesAsync();

            // Create and add transports for the new school
            foreach (var transport in request.Transports)
            {
                var newTransport = new Transport
                {
                    BusNumber = transport.BusNumber,
                    SchoolId = school.Id // Link to the newly created school
                };
                _schoolContext.Transports.Add(newTransport);
            }

            await _schoolContext.SaveChangesAsync();

            return Ok(new { Message = "School added successfully." });
        }

        [HttpPost("add-transport")]
        public async Task<IActionResult> AddTransport([FromBody] AddBusDTO request)
        {
            if (string.IsNullOrEmpty(request.BusNumber) || string.IsNullOrEmpty(request.SchoolName))
            {
                return BadRequest("Bus number and school name are required.");
            }

            // Check if the school exists
            var school = await _schoolContext.Schools
                .FirstOrDefaultAsync(s => s.Name == request.SchoolName);

            if (school == null)
            {
                return NotFound($"School with name '{request.SchoolName}' does not exist.");
            }

            // Check if the bus number already exists and is assigned to another school
            var existingTransport = await _schoolContext.Transports
                .FirstOrDefaultAsync(t => t.BusNumber == request.BusNumber);

            if (existingTransport != null)
            {
                // If the bus number exists and is assigned to a different school
                if (existingTransport.SchoolId != school.Id)
                {
                    return Conflict($"Bus number '{request.BusNumber}' is already assigned to another school. Please choose a different bus number.");
                }

                // If the bus number exists but is assigned to the same school, you might want to handle this case differently (optional)
                return BadRequest($"Bus number '{request.BusNumber}' is already assigned to this school.");
            }

            // Create a new transport
            var transport = new Transport
            {
                BusNumber = request.BusNumber,
                SchoolId = school.Id // Link to the existing school
            };

            // Add the transport to the context
            _schoolContext.Transports.Add(transport);
            await _schoolContext.SaveChangesAsync();

            return Ok(new { Message = "Transport added successfully." });
        }

    }
}