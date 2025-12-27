using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Infrastructure.Data;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FacilityManagementSystem.Infrastructure.Implementation
{

    public class AreaRepository: IAreaRepository
    {
        private readonly ApplicationDbContext _context;

        public AreaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //get all assets in area
        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            return await _context.Areas.Include(a => a.Assets).ToListAsync();

        }
        
        public async Task<Area?> GetByIdAsync(int id)
        {
            return await _context.Areas.Include(a => a.Assets).FirstOrDefaultAsync(a=>a.Id==id);
        }
        public async Task<Area> AddAsync(Area entity)
        {
            await _context.Areas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Area> UpdateAsync(Area entity)
        {
             _context.Areas.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteAsync(int id)
        {
           var area= await _context.Areas.FindAsync(id);
            if(area==null)
                return false;
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<IEnumerable<Area>> GetAreasByFacilityId(int facilityId)
        {
            
            return await _context.Areas
                .Where(a => a.FacilityId == facilityId)
                .Include(a => a.Assets)
                .ToListAsync();
            

        }
    }
}
