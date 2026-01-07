using FacilityManagementSystem.Application.DTOs.AssetDto;

namespace FacilityManagementSystem.Application.DTOs.AreaDto
{
    public class AreaReadDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public int FacilityId { get; set; }

        public List<AssetReadDto> ? Assets { get; set; }
    }

}
