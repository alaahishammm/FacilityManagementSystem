using Microsoft.AspNetCore.Http;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Application.DTOs.AreaDto;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace FacilityManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AreaController : ControllerBase
    {
        readonly IAreaService _areaService;
        readonly IMapper _mapper;
        public AreaController(IAreaService areaService , IMapper mapper)
        {
            _areaService = areaService;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin,Technician,Employee")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var areas = await _areaService.GetAllAsync();
            return Ok(areas);
        }
        [Authorize(Roles = "Admin,Technician,Employee")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById( int id)
        {
            var area = await _areaService.GetByIdAsync(id);
            if (area == null) return NotFound();

            return Ok(area);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]AreaCreateDto dto)
        {
            var areaDto = await _areaService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = areaDto.Id },
                areaDto);


        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateAsync (int id , [FromBody] AreaUpdateDto dto)
        {
            var UpdatedArea = await _areaService.UpdateAsync(id ,dto);
            return Ok(UpdatedArea);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
             await _areaService.DeleteAsync(id);

            return Ok("Area Deleted Successfully");
        }
    }
}
