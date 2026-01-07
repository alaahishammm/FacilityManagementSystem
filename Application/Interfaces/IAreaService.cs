using FacilityManagementSystem.Application.DTOs.AreaDto;
namespace FacilityManagementSystem.Application.Interfaces
{
    public interface IAreaService
    {
       
            Task<IEnumerable<AreaReadDto>> GetAllAsync();
            Task<AreaReadDto> GetByIdAsync(int id);
            Task<AreaReadDto> CreateAsync(AreaCreateDto dto);
            Task<AreaReadDto> UpdateAsync(int id, AreaUpdateDto dto);
            Task<bool> DeleteAsync(int id);
       
    }
}
