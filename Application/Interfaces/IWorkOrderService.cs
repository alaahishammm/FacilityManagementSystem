using FacilityManagementSystem.Application.DTOs.WorkOrderDto;
using FacilityManagementSystem.Domain.Enums;
namespace FacilityManagementSystem.Application.Interfaces
{
    public interface IWorkOrderService
    {

        Task<IEnumerable<WorkOrderReadDto>> GetAllAsync();
        Task<WorkOrderReadDto?> GetByIdAsync(int id);

        Task<IEnumerable<WorkOrderReadDto>> GetByStatusAsync(WorkOrderStatus status);
        Task<IEnumerable<WorkOrderReadDto>> GetByTechnicianAsync(int technicianId);

        Task<WorkOrderReadDto> CreateAsync(WorkOrderCreateDto dto);
        Task<WorkOrderReadDto> UpdateStatusAsync(int id, WorkOrderStatus status);

        Task<bool> DeleteAsync(int id);
    }
}
