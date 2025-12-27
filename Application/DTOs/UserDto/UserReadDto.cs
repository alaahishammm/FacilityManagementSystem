namespace FacilityManagementSystem.Application.DTOs.UserDto
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
