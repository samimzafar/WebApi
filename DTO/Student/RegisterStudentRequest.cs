using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO.Student
{
    public class RegisterStudentRequestDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string SchoolName { get; set; }
        public string BusNumber { get; set; }
    }
}