namespace FacilityManagementSystem.Application.DTOs.RequestDto
{
    public class RequestReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserDto.UserReadDto CreatedBy { get; set; } = null!;
    }
}
