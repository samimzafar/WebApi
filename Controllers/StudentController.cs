using Microsoft.AspNetCore.Mvc;
using WebApi.DTO.School;
using WebApi.DTO.Student;
using WebApi.DTO.Transport;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("register-student")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Address) ||
                string.IsNullOrEmpty(request.SchoolName) || string.IsNullOrEmpty(request.BusNumber))
            {
                return BadRequest("Name, address, age, school name, and bus number are required.");
            }

            try
            {
                await _studentService.RegisterStudentAsync(request);
                return Ok(new { Message = "Student registered successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid student ID.");
            }
            try
            {
                var studentDto = await _studentService.GetStudentDetailsAsync(id);
                if (studentDto == null)
                {
                    return NotFound(new { Message = $"Student with ID {id} not found." });
                }

                return Ok(studentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the student.", Error = ex.Message });
            }
        }

    }
}