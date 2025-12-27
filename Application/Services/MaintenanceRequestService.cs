using AutoMapper;

using FacilityManagementSystem.Application.DTOs.RequestDto;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Application.Mapping;
using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;

namespace FacilityManagementSystem.Application.Services
{
    public class MaintenanceRequestService : IMaintenanceRequestService
    {
        private readonly IMaintenanceRequestRepository _requestRepo;
        private readonly IAssetRepository _assetRepo;
        private readonly IMapper _mapper;

        public MaintenanceRequestService(
            IMaintenanceRequestRepository requestRepo,
            IAssetRepository assetRepo,
            IMapper mapper)
        {
            _requestRepo = requestRepo;
            _assetRepo = assetRepo;
            _mapper = mapper;
        }
        public async Task<RequestReadDto> GetByIdAsync(int id)
        {
            var request = await _requestRepo.GetByIdAsync(id);
            if (request == null)
                throw new KeyNotFoundException($"Maintenance Request with id {id} not found.");
            return _mapper.Map<RequestReadDto>(request);

        }
        public async Task<IEnumerable<RequestReadDto>> GetAllAsync()
        {
            var requests = await _requestRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<RequestReadDto>>(requests);

        }
        public async Task CreateAsync(RequestCreateDto dto)
        {

            if (dto.AssetId.HasValue)
            {
                var asset = await _assetRepo.GetByIdAsync(dto.AssetId.Value);
                if (asset == null)
                    throw new KeyNotFoundException($"Asset with id {dto.AssetId.Value} not found.");
                asset.Status = AssetStatus.NeedsMaintenance;
                await _assetRepo.UpdateAsync(asset);

            }
            
            
            var request = _mapper.Map<MaintenanceRequest>(dto);
            request.CreatedAt = DateTime.UtcNow;
            await _requestRepo.CreateAsync(request);
            

        }
       
        public async Task  DeleteAsync(int id)
        {
            var existing = await _requestRepo.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Maintenance Request with id {id} not found.");

               if(existing.Asset.Status == AssetStatus.Working)
                throw new Exception("Cannot delete a maintenance request for an asset that is working.");
            await _requestRepo.DeleteAsync(existing);


        }
        public async Task<IEnumerable<RequestReadDto>> GetByUserIdAsync(int userId)
        {
            var requests = await _requestRepo.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<RequestReadDto>>(requests);
        }
        public async Task<IEnumerable<RequestReadDto>> GetByAssetIdAsync(int assetId)
        {
            var requests = await _requestRepo.GetByUserIdAsync(assetId);
            return _mapper.Map<IEnumerable<RequestReadDto>>(requests);
        }
        public async Task<IEnumerable<RequestReadDto>> GetPendingRequestsAsync()
        {
            var requests = await _requestRepo.GetPendingRequestsAsync();
            return _mapper.Map<IEnumerable<RequestReadDto>>(requests);
        }
    }
}
