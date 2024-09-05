using System;
using WebApi.Models;

namespace WebApi.Repository;

public interface IStudent
{
    Task<Student> GetStudentByIdAsync(int id);
    Task<School> GetSchoolByNameAsync(string schoolName);
    Task<Transport> GetTransportByBusNumberAndSchoolIdAsync(string busNumber, int schoolId);
    Task AddStudentAsync(Student student);
}
