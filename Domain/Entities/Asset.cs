using FacilityManagementSystem.Domain.Enums;

namespace FacilityManagementSystem.Domain.Entities
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public string Category { get; set; } = null!;
        public DateTime InstalledAt { get; set; }

        public int FacilityId { get; set; }
        public Facility Facility { get; set; } = null!;

        public int? AreaId { get; set; }
        public Area Area { get; set; } = null!;
        public AssetStatus Status { get; set; } 


        public ICollection<MaintenanceRequest>? MaintenanceRequests { get; set; }
    }
}
