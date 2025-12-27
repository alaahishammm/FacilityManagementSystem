namespace FacilityManagementSystem.Application.DTOs.WorkOrderDto
{
    public class WorkOrderReadDto
    {
        public int Id { get; set; }
        public int RequestId { get; set; }

        public int TechnicianId { get; set; }
        public string TechnicianName { get; set; } = null!;

        public DateTime AssignedAt { get; set; }
        public int Status { get; set; }
        public string? Notes { get; set; }
    }
}
