namespace FacilityManagementSystem.Application.DTOs.RequestDto
{
    public class RequestCreateDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int FacilityId { get; set; }
        public int? AreaId { get; set; }
        public int? AssetId { get; set; }
        public int CreatedById { get; set; }
    }
}
