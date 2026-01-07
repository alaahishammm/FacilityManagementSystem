using AutoMapper;
using FacilityManagementSystem.Application.DTOs.AreaDto;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Application.Mapping;
using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FacilityManagementSystem.Application.Services
{
    public class AreaService: IAreaService
    {
        private readonly IAreaRepository _areaRepo;
        private readonly IMapper _mapper;

        public AreaService(IAreaRepository areaRepo, IMapper mapper)
        {
            _areaRepo = areaRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AreaReadDto>> GetAllAsync()
        {
            var areas = await _areaRepo.GetAllAsync();
            return  _mapper.Map<IEnumerable<AreaReadDto>>(areas);
        }

        public async Task<AreaReadDto> GetByIdAsync(int id)
        {
            var area = await _areaRepo.GetByIdAsync(id);
            if (area == null)

                throw new KeyNotFoundException($"Area with id {id} not found.");

            return _mapper.Map<AreaReadDto>(area);
        }
       public async  Task<AreaReadDto> CreateAsync(AreaCreateDto dto)
        {
            var area = _mapper.Map<Area>(dto);
             await _areaRepo.AddAsync(area);
            return _mapper.Map<AreaReadDto>(area);
        }
        public async Task<AreaReadDto> UpdateAsync(int id, AreaUpdateDto dto)  
        { 
            var existing  = await _areaRepo .GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Area with id {id} not found.");
            _mapper.Map(dto, existing);
            await _areaRepo.UpdateAsync(existing);
            return _mapper.Map<AreaReadDto>(existing);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _areaRepo.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Area with id {id} not found.");
            return await _areaRepo.DeleteAsync(id);
        }

    }
}
