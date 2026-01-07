using FluentValidation;
using FacilityManagementSystem.Application.DTOs.FacilityDto;

namespace FacilityManagementSystem.Application.Validators.Facility
{
    public class FacilityUpdateDtoValidator : AbstractValidator<FacilityUpdateDto>
    {
        public FacilityUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .When(x => x.Name != null);

            RuleFor(x => x.Location)
                .NotEmpty()
                .MaximumLength(200)
                .When(x => x.Location != null);
        }
    }
}
