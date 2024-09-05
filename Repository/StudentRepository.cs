using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repository;

public class StudentRepository : IStudent
{
    private readonly SchoolContext _schoolContext;

    public StudentRepository(SchoolContext schoolContext)
    {
        _schoolContext = schoolContext;
    }

    public async Task AddStudentAsync(Student student)
    {
        _schoolContext.Students.Add(student);
        await _schoolContext.SaveChangesAsync();
    }

    public async Task<School> GetSchoolByNameAsync(string schoolName)
    {
        var response = await _schoolContext.Schools
                .FirstOrDefaultAsync(s => s.Name == schoolName);
        return response;
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        var response = await _schoolContext.Students
            .Include(s => s.School)
            .Include(s => s.Transport)
            .FirstOrDefaultAsync(s => s.Id == id);
        return response;
    }

    public async Task<Transport> GetTransportByBusNumberAndSchoolIdAsync(string busNumber, int schoolId)
    {
        var response = await _schoolContext.Transports
                       .FirstOrDefaultAsync(t => t.BusNumber == busNumber && t.SchoolId == schoolId);
        return response;
    }
}
