namespace FacilityManagementSystem.Application.DTOs.AssetDto
{
    public class AssetReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public string Category { get; set; } = null!;
        public DateTime InstalledAt { get; set; }
        public string? Status { get; set; }

        public int FacilityId { get; set; }
        public string FacilityName { get; set; } = null!;

        public int? AreaId { get; set; }
        public string? AreaName { get; set; }
        


    }
}
