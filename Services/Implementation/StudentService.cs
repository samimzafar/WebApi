using WebApi.DTO.School;
using WebApi.DTO.Student;
using WebApi.DTO.Transport;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Services.Implementation;

public class StudentService : IStudentService
{
    private readonly IStudent _studentRepository;

    public StudentService(IStudent studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task AddStudentAsync(Student student)
    {
        await _studentRepository.AddStudentAsync(student);
    }

    public async Task<School> GetSchoolByNameAsync(string schoolName)
    {
        return await _studentRepository.GetSchoolByNameAsync(schoolName);
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        return await _studentRepository.GetStudentByIdAsync(id);
    }

    public async Task<GetStudentDto> GetStudentDetailsAsync(int id)
    {
        var student = await _studentRepository.GetStudentByIdAsync(id);
        if (student == null)
        {
            return null;
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
        return studentDto;
    }

    public async Task<Transport> GetTransportByBusNumberAndSchoolIdAsync(string busNumber, int schoolId)
    {
        return await _studentRepository.GetTransportByBusNumberAndSchoolIdAsync(busNumber, schoolId);
    }

    public async Task RegisterStudentAsync(RegisterStudentRequestDTO request)
    {
        // Check if the school exists
        var school = await GetSchoolByNameAsync(request.SchoolName);

        if (school == null)
        {
            throw new Exception($"School with name '{request.SchoolName}' does not exist.");
        }

        // Check if the bus number exists and is assigned to the specified school
        var transport = await GetTransportByBusNumberAndSchoolIdAsync(request.BusNumber, school.Id);

        if (transport == null)
        {
            throw new Exception($"Bus number '{request.BusNumber}' is not assigned to the school '{request.SchoolName}' or does not exist.");
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
        await AddStudentAsync(student);
    }
}

