namespace FacilityManagementSystem.Domain.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public int FacilityId { get; set; }
        public Facility Facility { get; set; } = null!;

        public ICollection<Asset>? Assets { get; set; }
    }
}
