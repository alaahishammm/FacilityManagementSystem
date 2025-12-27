using FacilityManagementSystem.Application.DTOs.RequestDto;
using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Infrastructure.Data;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
namespace FacilityManagementSystem.Infrastructure.Implementation
{
    public class MaintenanceRequestRepository : IMaintenanceRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       public async Task<MaintenanceRequest?> GetByIdAsync(int id)
        {
            return await _context.MaintenanceRequests
              .Include(m => m.CreatedBy)
              .Include(m => m.Asset)
              .Include(m => m.WorkOrder)
              .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<IEnumerable<MaintenanceRequest>> GetAllAsync()
        {
            return await _context.MaintenanceRequests
              .Include(m => m.CreatedBy)
              .Include(m => m.Asset)
              .Include(m => m.WorkOrder)
              .ToListAsync();
        }
        public async Task<IEnumerable<MaintenanceRequest>> GetByUserIdAsync(int userId)
        {
            return await _context.MaintenanceRequests
              .Where(m => m.CreatedById == userId)
              .Include(m => m.CreatedBy)
              .Include(m => m.Asset)
              .Include(m => m.WorkOrder)
              .ToListAsync();
        }
        public async Task<IEnumerable<MaintenanceRequest>> GetByAssetIdAsync(int assetId)
        {
            return await _context.MaintenanceRequests
              .Where(m => m.AssetId == assetId)
              .Include(m => m.CreatedBy)
              .Include(m => m.Asset)
              .Include(m => m.WorkOrder)
              .ToListAsync();
        }
        public async Task<MaintenanceRequest> CreateAsync(MaintenanceRequest request)
        {
            _context.MaintenanceRequests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task UpdateAsync(MaintenanceRequest request)  
        { 
            var existing = await _context.MaintenanceRequests.FindAsync(request.Id);
            if (existing != null)
            {
                existing.Title = request.Title;
                existing.Description = request.Description;
                existing.Priority = request.Priority;
                existing.AssetId = request.AssetId;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(MaintenanceRequest request)
        {
            _context.MaintenanceRequests.Remove(request);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<MaintenanceRequest>> GetPendingRequestsAsync()
        {
            var requests = await _context.MaintenanceRequests.Include(m=>m.Asset)
                .Include(m => m.CreatedBy).Where(M=>M.WorkOrder==null).ToListAsync();
            return requests;

                
        }
    }
}
