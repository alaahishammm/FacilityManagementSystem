using FacilityManagementSystem.Application.DTOs.FacilityDto;
namespace FacilityManagementSystem.Application.Interfaces
{
    public interface IFacilityService
    {
        Task<IEnumerable<FacilityReadDto>> GetAllAsync();
        Task<FacilityReadDto> GetByIdAsync(int id);
        Task<FacilityReadDto> CreateAsync(FacilityCreateDto dto);
        Task<FacilityReadDto> UpdateAsync(int id, FacilityUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
