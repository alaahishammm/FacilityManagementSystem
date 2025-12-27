using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;
using FacilityManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FacilityManagementSystem.Infrastructure.Repositories;

namespace FacilityManagementSystem.Infrastructure.Implementation
{
    public class WorkOrderRepository : IWorkOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<WorkOrder>> GetAllAsync()
        {
            return await _context.WorkOrders
                .Include(w => w.Technician)
                .Include(w => w.MaintenanceRequest)
                .ToListAsync();
        }

        public async Task<WorkOrder?> GetByIdAsync(int id)
        {
            return await _context.WorkOrders
                .Include(w => w.Technician)
                .Include(w => w.MaintenanceRequest)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<WorkOrder>> GetByTechnicianIdAsync(int technicianId)
        {
            return await _context.WorkOrders
                .Where(w => w.TechnicianId == technicianId)
                .Include(w => w.MaintenanceRequest)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkOrder>> GetByStatusAsync(WorkOrderStatus status)
        {
            return await _context.WorkOrders
                .Where(w => w.Status == status)
                .Include(w => w.Technician)
                .ToListAsync();
        }

        public async Task<WorkOrder> CreateAsync(WorkOrder workOrder)
        {
            _context.WorkOrders.Add(workOrder);
            await _context.SaveChangesAsync();
            return workOrder;
        }

        public async Task UpdateAsync(WorkOrder workOrder)
        {
            var existingWorkOrder = await _context.WorkOrders.FindAsync(workOrder.Id);
            if (existingWorkOrder != null)
            {
                existingWorkOrder.TechnicianId = workOrder.TechnicianId;
                existingWorkOrder.MaintenanceRequestId = workOrder.MaintenanceRequestId;
                existingWorkOrder.Status = workOrder.Status;
                existingWorkOrder.AssignedAt = workOrder.AssignedAt;
                existingWorkOrder.CompletedAt= workOrder.CompletedAt;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(WorkOrder workOrder)
        {
            _context.WorkOrders.Remove(workOrder);
            await _context.SaveChangesAsync();
        }
    }
}
