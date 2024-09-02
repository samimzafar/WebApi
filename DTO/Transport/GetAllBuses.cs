using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO.Transport
{
    public class GetAllBusesDTO
    {
        public int BusID { get; set; }
        public string BusNumber { get; set; }
    }
}