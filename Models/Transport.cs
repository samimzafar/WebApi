using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Transport
    {
        public int Id { get; set; }
        public string BusNumber { get; set; }=string.Empty;
        public int SchoolId { get; set; }
        
        public School School { get; set; }
    }
}