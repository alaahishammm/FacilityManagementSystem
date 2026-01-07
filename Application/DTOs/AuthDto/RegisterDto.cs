using FacilityManagementSystem.Domain.Enums;

namespace FacilityManagementSystem.Application.DTOs.AuthDto
{
    public class RegisterDto
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; }
    }
}
