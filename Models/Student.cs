using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public int TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}