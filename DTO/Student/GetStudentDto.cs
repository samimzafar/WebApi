using WebApi.DTO.School;
using WebApi.DTO.Transport;

namespace WebApi.DTO.Student
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public SchoolDTO School { get; set; }
        public TransportDTO Transport { get; set; }
    }
}