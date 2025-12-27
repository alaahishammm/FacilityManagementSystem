using FacilityManagementSystem.Application.DTOs.AssetDto;
using FacilityManagementSystem.Domain.Enums;
namespace FacilityManagementSystem.Application.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetReadDto>> GetAllAsync();
        Task<AssetReadDto?> GetByIdAsync(int id);

        Task<AssetReadDto> CreateAsync(AssetCreateDto dto);
        Task<AssetReadDto?> UpdateAsync(int id, AssetUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<AssetReadDto>> GetByAreaIdAsync(int areaId);
        Task<IEnumerable<AssetReadDto>> GetByStatusAsync();

    }
}
