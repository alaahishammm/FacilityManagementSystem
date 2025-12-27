namespace FacilityManagementSystem.Application.DTOs.RequestDto
{
    public class RequestUpdateDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Status { get; set; }
    }
}
