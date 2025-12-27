using FacilityManagementSystem.Application.DTOs.UserDto;

namespace FacilityManagementSystem.Application.Interfaces
  
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(int id);

        Task<IEnumerable<UserReadDto>> GetTechniciansAsync();

        Task<UserReadDto> CreateAsync(UserCreateDto dto);
        Task<UserReadDto> UpdateAsync(int id, UserUpdateDto dto);
        Task DeleteAsync(int id);



    }
}
