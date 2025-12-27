using AutoMapper;

using FacilityManagementSystem.Application.DTOs.FacilityDto;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Application.Mapping;
using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
namespace FacilityManagementSystem.Application.Services
{
    public class FacilityService: IFacilityService
    {
        private readonly IFacilityRepository _facilityRepo;
        private readonly IMapper _mapper;
        public FacilityService(
            IFacilityRepository facilityRepo,
            IMapper mapper)
        {
            _facilityRepo = facilityRepo;
            _mapper = mapper;
        }
       public async Task<IEnumerable<FacilityReadDto>> GetAllAsync()
        {
            var facilities = await _facilityRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<FacilityReadDto>>(facilities);
        }
        public async Task<FacilityReadDto> GetByIdAsync(int id)
        {
            var facility = await _facilityRepo.GetWithAreasAsync(id);
            if (facility == null)
            
                throw  new KeyNotFoundException($"facility with id {id} not found.");
            
            return _mapper.Map<FacilityReadDto>(facility);
        }
        public async Task<FacilityReadDto> CreateAsync(FacilityCreateDto dto)
        {
            var facility = _mapper.Map<Facility>(dto);
            await _facilityRepo.CreateAsync(facility);
            return _mapper.Map<FacilityReadDto>(facility);
        }
        public async Task<FacilityReadDto> UpdateAsync(int id, FacilityUpdateDto dto)
        {
            var existing = await _facilityRepo.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Facility with id {id} not found.");
            _mapper.Map(dto, existing);
            await _facilityRepo.UpdateAsync(existing);
            return _mapper.Map<FacilityReadDto>(existing);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _facilityRepo.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Facility with id {id} not found.");
            return await _facilityRepo.DeleteAsync(id);
        }
    }
}
