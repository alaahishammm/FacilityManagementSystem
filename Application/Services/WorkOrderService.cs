using AutoMapper;
using FacilityManagementSystem.Application.DTOs.WorkOrderDto;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Application.Mapping;
using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
namespace FacilityManagementSystem.Application.Services
{
    public class WorkOrderService : IWorkOrderService
    {
        private readonly IWorkOrderRepository _workOrderRepo;
        private readonly IMaintenanceRequestRepository _requestRepo;
        private readonly IUserRepository _userRepo;
        private readonly IAssetRepository _assetRepo;
        private readonly IMapper _mapper;


        public WorkOrderService(
            IWorkOrderRepository workOrderRepo,
            IMaintenanceRequestRepository requestRepo,
            IUserRepository userRepo,
            IAssetRepository assetRepo,
            IMapper mapper)
        {
            _workOrderRepo = workOrderRepo;
            _requestRepo = requestRepo;
            _userRepo = userRepo;
            _assetRepo = assetRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<WorkOrderReadDto>> GetAllAsync()
        {
            var workOrders = await _workOrderRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<WorkOrderReadDto>>(workOrders);
        }
        public async Task<WorkOrderReadDto?> GetByIdAsync(int id)
        {
            var workOrder = await _workOrderRepo.GetByIdAsync(id);
            if (workOrder == null)
                throw new KeyNotFoundException($"WorkOrder with id {id} not found.");
            return _mapper.Map<WorkOrderReadDto>(workOrder);
        }

        public async Task<IEnumerable<WorkOrderReadDto>> GetByStatusAsync(WorkOrderStatus status)
        {
            var workOrders = await _workOrderRepo.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<WorkOrderReadDto>>(workOrders);

        }
        public async Task<IEnumerable<WorkOrderReadDto>> GetByTechnicianAsync(int technicianId)
        {
            var workOrders = await _workOrderRepo.GetByTechnicianIdAsync(technicianId);
            return _mapper.Map<IEnumerable<WorkOrderReadDto>>(workOrders);
        }

        public async Task<WorkOrderReadDto> CreateAsync(WorkOrderCreateDto dto)
        {
            
            var request = await _requestRepo.GetByIdAsync(dto.RequestId);
            if (request == null)
                throw new KeyNotFoundException($"Maintenance Request with id {dto.RequestId} not found.");

            if (request.WorkOrder != null)
                throw new InvalidOperationException("This request already has a work order.");

            var technician = await _userRepo.GetByIdAsync(dto.TechnicianId);
            if (technician == null || technician.Role != Role.Technician)
                throw new InvalidOperationException("Invalid technician.");

            
            if (request.Asset != null)
            {
                request.Asset.Status = AssetStatus.NeedsMaintenance;
            }

            
            var workOrder = new WorkOrder
            {
                MaintenanceRequestId = request.Id,
                TechnicianId = technician.Id,
                Notes = dto.Notes,
                AssignedAt = DateTime.UtcNow,
                Status = WorkOrderStatus.Pending,
                Priority = request.Priority
            };

            await _workOrderRepo.CreateAsync(workOrder);

            return _mapper.Map<WorkOrderReadDto>(workOrder);
        }

        public async Task<WorkOrderReadDto> UpdateStatusAsync(int id, WorkOrderStatus status)
        {
            var workOrder = await _workOrderRepo.GetByIdAsync(id);

            if (workOrder == null)
                throw new KeyNotFoundException($"WorkOrder with id {id} not found.");

            if (workOrder.Status == WorkOrderStatus.Completed)
                throw new InvalidOperationException("Cannot update a completed work order.");

            workOrder.Status = status;

            if (status == WorkOrderStatus.Completed)
            {
                workOrder.CompletedAt = DateTime.UtcNow;

                if (workOrder.MaintenanceRequest?.Asset != null)
                    workOrder.MaintenanceRequest.Asset.Status = AssetStatus.Working;
            }

            await _workOrderRepo.UpdateAsync(workOrder);

            return _mapper.Map<WorkOrderReadDto>(workOrder);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var workOrder = await _workOrderRepo.GetByIdAsync(id);

            if (workOrder == null)
                throw new KeyNotFoundException($"WorkOrder with id {id} not found.");

            if (workOrder.Status == WorkOrderStatus.Completed )
                throw new InvalidOperationException("Cannot delete a completed work order.");

            if (workOrder.MaintenanceRequest != null)
                workOrder.MaintenanceRequest.WorkOrder = null ;

            await _workOrderRepo.DeleteAsync(workOrder);

            return true;
        }

    }
}
