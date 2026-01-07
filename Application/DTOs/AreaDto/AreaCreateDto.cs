using FacilityManagementSystem.Domain.Entities;

namespace FacilityManagementSystem.Application.DTOs.AreaDto
{
    public class AreaCreateDto
    {
        public string Type { get; set; } = null!;
        public int FacilityId { get; set; }
      


    }
}
