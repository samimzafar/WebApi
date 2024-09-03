using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO.Transport;

namespace WebApi.DTO.School
{
    public class AddSchoolRequestDTO
    {
        public string Name { get; set; }=string.Empty;
        public string Location { get; set; }=string.Empty;
        public decimal Fees { get; set; }
        public bool Open { get; set; }
        public List<AddTransportRequestDTO> Transports { get; set; }=new List<AddTransportRequestDTO>();
    }
}