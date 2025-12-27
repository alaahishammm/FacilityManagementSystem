using FacilityManagementSystem.Application.DTOs.AssetDto;
using FacilityManagementSystem.Domain.Entities;

namespace FacilityManagementSystem.Application.DTOs.AreaDto
{
    public class AreaUpdateDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public int FacilityId { get; set; }
        public Facility Facility { get; set; } = null!;

        public ICollection<Asset>? Assets { get; set; }
    }
}
