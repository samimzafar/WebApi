using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO.Transport
{
    public class AddBusDTO
    {
        public string BusNumber { get; set; }=string.Empty;
        public string SchoolName { get; set; }=string.Empty;
    }
}