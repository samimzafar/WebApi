using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO.Transport;

namespace WebApi.DTO
{
   public class GetAllSchoolsDTO
{
    public string Name { get; set; }=string.Empty;
    public string Location { get; set; }=string.Empty;
    public decimal Fees { get; set; }
    public List<GetAllBusesDTO> Transports { get; set; }=new List<GetAllBusesDTO>();
}
}