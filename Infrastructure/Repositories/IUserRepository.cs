using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;

namespace FacilityManagementSystem.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        
        Task<IEnumerable<User>> GetByRoleAsync(Role role);
        Task<User> CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
