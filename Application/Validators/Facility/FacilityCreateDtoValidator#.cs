using FluentValidation;
using FacilityManagementSystem.Application.DTOs.FacilityDto;

namespace FacilityManagementSystem.Application.Validators.Facility
{
    public class FacilityCreateDtoValidator : AbstractValidator<FacilityCreateDto>
    {
        public FacilityCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Facility name is required")
                .MaximumLength(100);

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required")
                .MaximumLength(200);
        }
    }
}
