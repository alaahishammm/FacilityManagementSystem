using System;
using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Infrastructure.Data;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FacilityManagementSystem.Infrastructure.Implementation
{
    public class FacilityRepository:IFacilityRepository 
    {
        private readonly ApplicationDbContext _context;

        public FacilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Facility>> GetAllAsync()
        {
            return await _context.facilities.Include(f=>f.Area).ToListAsync();

        }
        public async Task<Facility?> GetByIdAsync(int id)
        {
            return await _context.facilities.FirstOrDefaultAsync(f=>f.Id==id);
        }
        public async Task CreateAsync(Facility facility)
        {
            await _context.facilities.AddAsync(facility);
            await _context.SaveChangesAsync();
           
        }
        public async Task UpdateAsync(Facility facility)
        {
            _context.facilities.Update(facility);
            await _context.SaveChangesAsync();
        }
        public async  Task<bool> DeleteAsync (int id)
        {
            var facility = await _context.facilities.FindAsync(id);
            if (facility == null)
                return false;
             _context.facilities.Remove(facility);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<IEnumerable<Facility>> SearchByNameAsync(string name)
        {
            var facilities = await _context.facilities.Where(f=>f.Name.Contains(name)).ToListAsync();
            return facilities;

        }
         public async Task<Facility?> GetWithAreasAsync(int id)
        {
            return await _context.facilities.Include(f=>f.Area).FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
