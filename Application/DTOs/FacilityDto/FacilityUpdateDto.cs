using System.Diagnostics.Contracts;

namespace FacilityManagementSystem.Application.DTOs.FacilityDto
{
    public class FacilityUpdateDto
    {
    
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
