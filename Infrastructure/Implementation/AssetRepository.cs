using FacilityManagementSystem.Domain.Entities; 
using FacilityManagementSystem.Infrastructure.Data; 
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;    
namespace FacilityManagementSystem.Infrastructure.Implementation
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _context;

        public AssetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _context.Assets.Include(a=>a.MaintenanceRequests )
             .Include(a=>a.Area).Include(a=>a.Facility).ToListAsync();
        }
        public async Task<Asset?> GetByIdAsync(int id)
        {
            return await _context.Assets.Include(a => a.MaintenanceRequests)
             .Include(a => a.Area).Include(a => a.Facility).FirstOrDefaultAsync(a=>a.Id==id);
        }
        public async Task<Asset> CreateAsync(Asset asset)
        {
            await _context.Assets.AddAsync(asset); 
            await _context.SaveChangesAsync();
            return asset;

        }
        public async Task<Asset?> UpdateAsync(Asset asset)
        {

            var existing = await _context.Assets.FindAsync(asset.Id);
            if (existing == null)
            {
                return null;
            }
            existing.Name = asset.Name;
            existing.Category = asset.Category;
            existing.SerialNumber = asset.SerialNumber;
            existing.Status = asset.Status;
            existing.AreaId = asset.AreaId;
            existing.FacilityId = asset.FacilityId;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
                return false;
            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
            return true;


        }
        public async Task<IEnumerable<Asset>> GetByAreaAsync(int areaId)
        {
            return await _context.Assets.Where(a => a.Id == areaId)
                .Include(a => a.MaintenanceRequests)
                .ToListAsync();
        }
        public async Task<IEnumerable<Asset>> GetByStatusAsync()
        {
            return await _context .Assets.Where(a=>a.Status== Domain.Enums.AssetStatus.NeedsMaintenance)
                .Include(a => a.MaintenanceRequests)
                .ToListAsync();

        }

       public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Assets.AnyAsync(a => a.Id == id);
        }
        public async Task<IEnumerable<Asset>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Assets
                .Include(a => a.MaintenanceRequests)
                
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

       public async Task<IEnumerable<Asset>> FilterAsync(
           string? name,
           string? category,
            Domain.Enums.AssetStatus? status,
           bool sortByNameAsc
       )
        {
            var query = _context.Assets.AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(a => a.Name.Contains(name));
            if (!string.IsNullOrWhiteSpace(category)) 
            query = query.Where(a => a.Category.Contains(category));
            if (status.HasValue)
                query = query.Where(a => a.Status == status.Value);
           //
            query = sortByNameAsc
        ? query.OrderBy(a => a.Name)
        : query.OrderByDescending(a => a.Name);

            return await query
                .Include(a => a.Facility)
                .Include(a => a.Area)
                .ToListAsync();
        }


    }
}
