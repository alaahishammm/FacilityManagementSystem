namespace FacilityManagementSystem.Application.DTOs.AuthDto
{
    public class AuthResponseDto
    {
       
            public int UserId { get; set; }
            public string FullName { get; set; } = null!;
            public string Role { get; set; } = null!;
            public string Token { get; set; } = null!;
        

    }
}
