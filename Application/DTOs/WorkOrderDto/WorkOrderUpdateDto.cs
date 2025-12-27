namespace FacilityManagementSystem.Application.DTOs.WorkOrderDto
{
    public class WorkOrderUpdateDto
    {
        public int TechnicianId { get; set; }
        public string Status { get; set; } = null!;
        public string? Note { get; set; }


    }
}
