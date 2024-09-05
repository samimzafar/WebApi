using Microsoft.AspNetCore.Mvc;
using WebApi.DTO.School;
using WebApi.DTO.Student;
using WebApi.DTO.Transport;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentRepository;

        public StudentController(IStudent studentRepo)
        {
            _studentRepository = studentRepo;
        }

        [HttpPost("register-student")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Address) ||
                string.IsNullOrEmpty(request.SchoolName) || string.IsNullOrEmpty(request.BusNumber))
            {
                return BadRequest("Name, address, age, school name, and bus number are required.");
            }

            // Check if the school exists
            var school = await _studentRepository.GetSchoolByNameAsync(request.SchoolName);

            if (school == null)
            {
                return NotFound($"School with name '{request.SchoolName}' does not exist.");
            }

            // Check if the bus number exists and is assigned to the specified school
            var transport = await _studentRepository.GetTransportByBusNumberAndSchoolIdAsync(request.BusNumber, school.Id);

            if (transport == null)
            {
                return NotFound($"Bus number '{request.BusNumber}' is not assigned to the school '{request.SchoolName}' or does not exist.");
            }

            // Create a new student
            var student = new Student
            {
                Name = request.Name,
                Address = request.Address,
                Age = request.Age,
                SchoolId = school.Id,
                TransportId = transport.Id // Link to the existing transport
            };

            // Add the student to the context
            await _studentRepository.AddStudentAsync(student);

            return Ok(new { Message = "Student registered successfully." });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDto = new GetStudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                Age = student.Age,
                School = new SchoolDTO
                {
                    Id = student.School.Id,
                    Name = student.School.Name,
                    Location = student.School.Location
                },
                Transport = new TransportDTO
                {
                    Id = student.Transport.Id,
                    BusNumber = student.Transport.BusNumber
                }
            };

            return Ok(studentDto);
        }

    }
}