using FacilityManagementSystem.Domain.Entities;

namespace FacilityManagementSystem.Infrastructure.Repositories
{
    public interface IFacilityRepository
    {
        // CRUD
        Task<IEnumerable<Facility>> GetAllAsync();
        Task<Facility?> GetByIdAsync(int id);
        Task CreateAsync(Facility facility);
        Task UpdateAsync(Facility facility);
        Task<bool> DeleteAsync  (int id);
        // Extras
        Task<IEnumerable<Facility>> SearchByNameAsync(string name);
        Task<Facility?> GetWithAreasAsync(int id);
        

       
    }
}
