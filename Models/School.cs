namespace WebApi.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Location { get; set; }=string.Empty;
        public decimal Fees { get; set; }
        public bool Open { get; set; } = true;
        
         public List<Transport> Transports { get; set; } = new List<Transport>();
        public List<Student> Students { get; set; }=new List<Student>();
    }
}