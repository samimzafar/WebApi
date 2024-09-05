namespace WebApi.DTO.Student
{
    public class RegisterStudentRequestDTO
    {
        public string Name { get; set; }=string.Empty;
        public string Address { get; set; }=string.Empty;
        public int Age { get; set; }
        public string SchoolName { get; set; }=string.Empty;
        public string BusNumber { get; set; }=string.Empty;
    }
}