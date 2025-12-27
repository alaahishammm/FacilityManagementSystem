using FacilityManagementSystem.Application.DTOs.RequestDto;

namespace FacilityManagementSystem.Application.Interfaces;
    public interface IMaintenanceRequestService
    {
    Task<RequestReadDto> GetByIdAsync(int id);
    Task<IEnumerable<RequestReadDto>> GetAllAsync();

    Task CreateAsync(RequestCreateDto request);
   
    Task DeleteAsync(int id);  
    Task<IEnumerable<RequestReadDto>> GetByUserIdAsync(int userId);
    Task<IEnumerable<RequestReadDto>> GetByAssetIdAsync(int assetId);
    Task<IEnumerable<RequestReadDto>> GetPendingRequestsAsync();


}

