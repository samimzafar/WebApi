using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Fees { get; set; }
        public bool Open { get; set; } = true;
        
         public List<Transport> Transports { get; set; } = new List<Transport>();
        public List<Student> Students { get; set; }
    }
}