namespace FacilityManagementSystem.Application.DTOs.WorkOrderDto
{
    public class WorkOrderCreateDto
    {
        public int RequestId { get; set; }
        public int TechnicianId { get; set; }
        public string? Notes { get; set; }
        public DateTime AssignedAt { get; set; }
        public string TechnicianName { get; set; } = null!;


    }
}
