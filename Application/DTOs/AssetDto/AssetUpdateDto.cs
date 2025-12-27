namespace FacilityManagementSystem.Application.DTOs.AssetDto
{
    public class AssetUpdateDto
    {
        public string Name { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public string Category { get; set; } = null!;
        public DateTime InstalledAt { get; set; }

        public int FacilityId { get; set; }
        public int? AreaId { get; set; }
    }
}
