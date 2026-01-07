using FacilityManagementSystem.Application.DTOs.AssetDto;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FacilityManagementSystem.Application.DTOs.FacilityDto;
using FacilityManagementSystem.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace FacilityManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IMapper _mapper;

        public AssetController(IAssetService assetService, IMapper mapper)
        {
            _assetService = assetService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,Technician,Employee")]

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assets = await _assetService.GetAllAsync();
            return Ok(assets);
        }
        [Authorize(Roles = "Admin,Technician,Employee")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var asset = await _assetService.GetByIdAsync(id);
            return Ok(asset);
        }
        [Authorize(Roles = "Admin,Technician,Employee")]
        [HttpGet("by-area/{areaId:int}")]
        public async Task<IActionResult> GetByArea(int areaId)
        {
            var assets = await _assetService.GetByAreaIdAsync(areaId);
            return Ok(assets);


        }
        [Authorize(Roles = "Admin")]
        [HttpGet("need-maintenance")]
        public async Task<IActionResult> GetAllNeedMaintenance()
        {
            var assets = await _assetService.GetByStatusAsync();
            return Ok( _mapper.Map<IEnumerable<AssetReadDto>>(assets));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AssetCreateDto dto)
        {
            var created = await _assetService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        
        }
        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> UpdateAsync(int id, [FromBody] AssetUpdateDto dto)
        //{
        //    var updated = await _assetService.UpdateAsync(id, dto);
        //    if (updated == null)
        //        return NotFound();
        //    return Ok(updated);
        //}
        [Authorize(Roles = "Admin")]

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _assetService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
        [Authorize(Roles = "Admin")]

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, AssetUpdateDto dto)
        {
            await _assetService.UpdateAsync(id, dto);
            return NoContent();
        }






    }
}
