using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Application.DTOs.RequestDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FacilityManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceRequestController : ControllerBase
    {
        private readonly IMaintenanceRequestService _requestService;

        public MaintenanceRequestController(IMaintenanceRequestService requestService)
        {
            _requestService = requestService;
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestCreateDto dto)
        {
            var result = await _requestService.CreateAsync(dto);
            return Ok(result);
        }

        [Authorize(Roles = "Admin,Technician,Employee")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _requestService.GetAllAsync();
            return Ok(requests);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _requestService.GetByIdAsync(id);
            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("pending")]
        public async Task<IActionResult> GetPending()
        {
            var requests = await _requestService.GetPendingRequestsAsync();
            return Ok(requests);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("asset-Id/{assetId:int}")]
        public async Task<IActionResult> GetByAssetId(int assetId)
        {
            var requests = await _requestService.GetByAssetIdAsync(assetId);
            return Ok(requests);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("user-Id/{userId:int}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var requests = await _requestService.GetByUserIdAsync(userId);
            return Ok(requests);
        }

        //// 🔹 Approve Request (Admin)
        //[HttpPut("{id:int}/approve")]
        //public async Task<IActionResult> Approve(int id)
        //{
        //    await _requestService.ApproveAsync(id);
        //    return NoContent();
        //}

        // 🔹 Reject Request (Admin)
        //[HttpPut("{id:int}/reject")]
        //public async Task<IActionResult> Reject(int id)
        //{
        //    await _requestService.RejectAsync(id);
        //    return NoContent();
        //}

        // 🔹 Delete Request
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _requestService.DeleteAsync(id);
            return NoContent();
        }
    }
}
