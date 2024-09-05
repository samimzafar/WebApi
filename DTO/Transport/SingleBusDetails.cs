using WebApi.DTO.School;
namespace WebApi.DTO.Transport
{
    public class SingleBusDetailsDTO
    {
        public string BusNumber { get; set; } = string.Empty;
        public SchoolDTO School { get; set; }
    }
}