using FacilityManagementSystem.Domain.Enums;

namespace FacilityManagementSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;
        public Role Role { get; set; } 


        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public ICollection<MaintenanceRequest>? CreatedRequests { get; set; }
        public ICollection<WorkOrder>? AssignedWorkOrders { get; set; }



    }
}
