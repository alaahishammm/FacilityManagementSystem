using FacilityManagementSystem.Application.DTOs.AssetDto;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace FacilityManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IMapper _mapper;

        public AssetController(IAssetService assetService, IMapper mapper)
        {
            _assetService = assetService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assets = await _assetService.GetAllAsync();
            return Ok(assets);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var asset = await _assetService.GetByIdAsync(id);
            return Ok(asset);
        }
        [HttpGet("by-area/{areaId:int}")]
        public async Task<IActionResult> GetByArea(int areaId)
        {
            var assets = await _assetService.GetByAreaIdAsync(areaId);
            return Ok(assets);


        }
        [HttpGet("need-maintenance")]
        public async Task<IActionResult> GetAllNeedMeaintance()
        {
            var assets = await _assetService.GetByStatusAsync();
            return Ok( _mapper.Map<IEnumerable<AssetReadDto>>(assets));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AssetCreateDto dto)
        {
            var created = await _assetService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] AssetUpdateDto dto)
        {
            var updated = await _assetService.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _assetService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }







    }
}
