using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Application.DTOs.WorkOrderDto;
using FacilityManagementSystem.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FacilityManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkOrderController : ControllerBase
    {
        private readonly IWorkOrderService _workOrderService;

        public WorkOrderController(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkOrderCreateDto dto)
        {
            var result = await _workOrderService.CreateAsync(dto);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _workOrderService.GetAllAsync();
            return Ok(orders);
        }

        // 🔹 Get Work Order By Id
        [Authorize(Roles = "Admin")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _workOrderService.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("technician/{technicianId:int}")]
        public async Task<IActionResult> GetByTechnician(int technicianId)
        {
            var orders = await _workOrderService.GetByTechnicianAsync(technicianId);
            return Ok(orders);
        }

        [Authorize(Roles = "Technician")]
        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] WorkOrderStatus status)
        {
            await _workOrderService.UpdateStatusAsync(id, status);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _workOrderService.DeleteAsync(id);
            return NoContent();
        }
    }
}

