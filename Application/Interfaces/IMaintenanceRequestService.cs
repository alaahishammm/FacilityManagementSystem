using FacilityManagementSystem.Application.DTOs.RequestDto;
using FacilityManagementSystem.Domain.Entities;

namespace FacilityManagementSystem.Application.Interfaces;
    public interface IMaintenanceRequestService
    {
    Task<RequestReadDto> GetByIdAsync(int id);
    Task<IEnumerable<RequestReadDto>> GetAllAsync();

    Task<RequestReadDto> CreateAsync(RequestCreateDto dto);
    Task DeleteAsync(int id);  
    Task<IEnumerable<RequestReadDto>> GetByUserIdAsync(int userId);
    Task<IEnumerable<RequestReadDto>> GetByAssetIdAsync(int assetId);
    Task<IEnumerable<RequestReadDto>> GetPendingRequestsAsync();


}

