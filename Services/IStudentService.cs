using System;
using WebApi.DTO.Student;
using WebApi.Models;

namespace WebApi.Services;

public interface IStudentService
{
    Task<Student> GetStudentByIdAsync(int id);
    Task<GetStudentDto> GetStudentDetailsAsync(int id);
    Task<School> GetSchoolByNameAsync(string schoolName);
    Task<Transport> GetTransportByBusNumberAndSchoolIdAsync(string busNumber, int schoolId);
    Task AddStudentAsync(Student student);
    Task RegisterStudentAsync(RegisterStudentRequestDTO request);
}
