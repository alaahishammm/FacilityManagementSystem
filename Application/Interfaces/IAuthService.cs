using FacilityManagementSystem.Application.DTOs.AuthDto;

namespace FacilityManagementSystem.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}
