using FacilityManagementSystem.Domain.Entities;

namespace FacilityManagementSystem.Application.DTOs.AreaDto
{
    public class AreaCreateDto
    {
        public int FacilityId { get; set; }
       
        public string Type { get; set; } = null!;
        
    }
}
