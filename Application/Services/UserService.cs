using AutoMapper;
using FacilityManagementSystem.Application.DTOs .UserDto;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Application.Mapping;
using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
namespace FacilityManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
       
        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<UserReadDto>>(users);

        }
        public async Task<UserReadDto> GetByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return _mapper.Map<UserReadDto>(user);

        }

        public async Task<IEnumerable<UserReadDto>> GetTechniciansAsync()
        {
            var technicians = await _userRepo.GetByRoleAsync(Role.Technician);
            return _mapper.Map<IEnumerable<UserReadDto>>(technicians);
        }

        public async Task<UserReadDto> CreateAsync(UserCreateDto dto)
        {
            var user = _mapper.Map<User>(dto);

            //  hashing
            user.PasswordHash = dto.Password;

            var createdUser = await _userRepo.CreateAsync(user);
            return _mapper.Map<UserReadDto>(createdUser);

        }
        public async Task<UserReadDto> UpdateAsync(int id, UserUpdateDto dto)
        {
            var existingUser = await _userRepo.GetByIdAsync(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            _mapper.Map(dto, existingUser);
            await _userRepo.UpdateAsync(existingUser);
            return _mapper.Map<UserReadDto>(existingUser);
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"User with id {id} not found");

            //if (user.AssignedWorkOrders.Any())
            //    throw new InvalidOperationException("Cannot delete technician with assigned work orders");

            await _userRepo.DeleteAsync(user);

        }
    }
}
