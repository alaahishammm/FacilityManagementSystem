 namespace FacilityManagementSystem.Domain.Entities
{
    public class Facility
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public ICollection<Area>? Area { get; set; }// 3adelyha fe el rebo ba3d el migrationnn addin areas
    }
}
