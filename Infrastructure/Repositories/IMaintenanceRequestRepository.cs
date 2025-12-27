using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;
namespace FacilityManagementSystem.Infrastructure.Repositories
{
    public interface IMaintenanceRequestRepository
    {
        Task<MaintenanceRequest?> GetByIdAsync(int id);
        Task<IEnumerable<MaintenanceRequest>> GetAllAsync();

        Task<IEnumerable<MaintenanceRequest>> GetByUserIdAsync(int userId);
        Task<IEnumerable<MaintenanceRequest>> GetByAssetIdAsync(int assetId);

        Task<MaintenanceRequest> CreateAsync(MaintenanceRequest request);
        Task UpdateAsync(MaintenanceRequest request);
        Task DeleteAsync(MaintenanceRequest request);
        Task<IEnumerable<MaintenanceRequest>> GetPendingRequestsAsync();
    }
}
