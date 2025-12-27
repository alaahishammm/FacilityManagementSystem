using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;
namespace FacilityManagementSystem.Infrastructure.Repositories
{
    public interface IWorkOrderRepository
    {
        Task<WorkOrder?> GetByIdAsync(int id);
        Task<IEnumerable<WorkOrder>> GetAllAsync();

        Task<IEnumerable<WorkOrder>> GetByTechnicianIdAsync(int technicianId);
        Task<IEnumerable<WorkOrder>> GetByStatusAsync(WorkOrderStatus status);

        Task<WorkOrder> CreateAsync(WorkOrder workOrder);
        Task UpdateAsync(WorkOrder workOrder);
        Task DeleteAsync(WorkOrder workOrder);
    }
}
