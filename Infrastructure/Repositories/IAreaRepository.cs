using FacilityManagementSystem.Domain.Entities;
using System.Threading.Tasks;   

namespace FacilityManagementSystem.Infrastructure.Repositories
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAllAsync();
        Task<Area?> GetByIdAsync(int id);
        Task<Area> AddAsync(Area entity);
        Task<Area> UpdateAsync(Area entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Area>> GetAreasByFacilityId(int facilityId);
    }
}
