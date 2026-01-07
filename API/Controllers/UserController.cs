using FacilityManagementSystem.Application.DTOs.UserDto;
using FacilityManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
[Authorize(Roles = "Admin")] // default
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateDto dto)
    {
        var user = await _userService.CreateAsync(dto);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("technicians")]
    [Authorize(Roles = "Admin,Technician")]
    public async Task<IActionResult> GetTechnicians()
    {
        return Ok(await _userService.GetTechniciansAsync());
    }
}
