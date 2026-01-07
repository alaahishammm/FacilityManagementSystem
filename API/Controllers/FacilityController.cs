
using Microsoft.AspNetCore.Http;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Application.DTOs.FacilityDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FacilityManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [Authorize(Roles = "Admin,Technician,Employee")]

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var facilities = await _facilityService.GetAllAsync();
            return Ok(facilities);
        }
        [Authorize(Roles = "Admin,Technician,Employee")]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var facility = await _facilityService.GetByIdAsync(id);
            if (facility == null)
                return NotFound($"Facility with id {id} not found");

            return Ok(facility);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FacilityCreateDto dto)
        {
            var CreatedFacility = await _facilityService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = CreatedFacility.Id }, CreatedFacility);
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] FacilityUpdateDto dto)
        //{
        //    var updatedFacility = await _facilityService.UpdateAsync(id, dto);
        //    return Ok(updatedFacility);
        //}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _facilityService.DeleteAsync(id);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, FacilityUpdateDto dto)
        {
            await _facilityService.UpdateAsync(id, dto);
            return NoContent();
        }

    }
}
