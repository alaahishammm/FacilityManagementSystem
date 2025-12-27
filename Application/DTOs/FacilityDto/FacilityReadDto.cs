using FacilityManagementSystem.Application.DTOs.AreaDto;

namespace FacilityManagementSystem.Application.DTOs.FacilityDto
{
    public class FacilityReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } =null!;

        public List<AreaReadDto>? Areas { get; set; }
    }
}
