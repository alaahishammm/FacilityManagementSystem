using FacilityManagementSystem.Domain.Enums;

namespace FacilityManagementSystem.Domain.Entities
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public string? Notes { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int MaintenanceRequestId { get; set; }

        public int TechnicianId { get; set; }
        public User Technician { get; set; } = null!;
        //enums
        public Priority Priority { get; set; }

        public WorkOrderStatus Status { get; set; }
        
        
        public MaintenanceRequest MaintenanceRequest { get; set; } = null!;
    }
}
