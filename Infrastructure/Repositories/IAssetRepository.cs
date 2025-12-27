using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;

namespace FacilityManagementSystem.Infrastructure.Repositories
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<Asset?> GetByIdAsync(int id);
        Task<Asset> CreateAsync(Asset asset);
        Task<Asset?> UpdateAsync(Asset asset);
        Task<bool> DeleteAsync(int id);

        // Extras
      
        Task<IEnumerable<Asset>> GetByAreaAsync(int areaId);
        Task<IEnumerable<Asset>> GetByStatusAsync();
        Task<bool> ExistsAsync(int id);

        // Pagination
        Task<IEnumerable<Asset>> GetPagedAsync(int page, int pageSize);

        // Filtering + sorting combo
        Task<IEnumerable<Asset>> FilterAsync(
            string? name,
            string? category,
            Domain.Enums.AssetStatus ? status,
            bool sortByNameAsc
        );
    }
}
