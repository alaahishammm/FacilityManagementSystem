using AutoMapper;
using FacilityManagementSystem.Application.DTOs.AreaDto;
using FacilityManagementSystem.Application.DTOs.AssetDto;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Application.Mapping;
using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
namespace FacilityManagementSystem.Application.Services

{
    public class AssetService : IAssetService
    {
        private readonly IMapper _mapper;
        private readonly IAssetRepository _assetRepo;

        public AssetService(IMapper mapper, IAssetRepository assetRepo)
        {

            _mapper = mapper;
            _assetRepo = assetRepo;

        }
        public async Task<IEnumerable<AssetReadDto>> GetAllAsync()
        {
            var assets = await _assetRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<AssetReadDto>>(assets);

        }
        public async Task<AssetReadDto?> GetByIdAsync(int id)
        {
            var asset = await _assetRepo.GetByIdAsync(id);
            if (asset == null)
                throw new KeyNotFoundException($"Asset with id {id} not found.");
            return _mapper.Map<AssetReadDto>(asset);

        }
        public async Task<IEnumerable<AssetReadDto>> GetByAreaIdAsync(int AreaId)
        {
            var asset = await _assetRepo.GetByAreaAsync(AreaId);
            if (asset == null)
                throw new KeyNotFoundException($"Assets with Area id {AreaId} not found.");
            return _mapper.Map<IEnumerable<AssetReadDto>>(asset);
        }
        public async Task<AssetReadDto> CreateAsync(AssetCreateDto dto)
        {
            var asset = _mapper.Map<Asset>(dto);
            var createdAsset = await _assetRepo.CreateAsync(asset);
            return _mapper.Map<AssetReadDto>(createdAsset);


        }
        public async Task<AssetReadDto?> UpdateAsync(int id, AssetUpdateDto dto)
        {
            var existing = await _assetRepo.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Asset with id {id} not found.");
            _mapper.Map(dto, existing);
            var updatedAsset = await _assetRepo.UpdateAsync(existing);
            return _mapper.Map<AssetReadDto>(updatedAsset);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _assetRepo.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Asset with id {id} not found.");
            return await _assetRepo.DeleteAsync(id);
        }
        public async Task<IEnumerable<AssetReadDto>> GetByStatusAsync()

        {
            var assets = await _assetRepo.GetByStatusAsync();
            return _mapper.Map<IEnumerable<AssetReadDto>>(assets);
        }
       
    }
}
