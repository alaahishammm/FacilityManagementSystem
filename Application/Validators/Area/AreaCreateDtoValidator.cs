using FluentValidation;
using FacilityManagementSystem.Application.DTOs.AreaDto;

public class AreaCreateDtoValidator : AbstractValidator<AreaCreateDto>
{
    public AreaCreateDtoValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Area type is required.")
            .MaximumLength(100).WithMessage("Area type must not exceed 100 characters.");

        RuleFor(x => x.FacilityId)
            .GreaterThan(0).WithMessage("FacilityId must be a valid id.");
    }
}
