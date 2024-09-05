namespace WebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Address { get; set; }=string.Empty;
        public int Age { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public int TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}