using FacilityManagementSystem.Domain.Enums;

namespace FacilityManagementSystem.Domain.Entities
{
    public class MaintenanceRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Priority Priority { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;

        public int? AssetId { get; set; }
        public Asset Asset { get; set; } = null!;

        public WorkOrder WorkOrder { get; set; } = null!;
    }
}
