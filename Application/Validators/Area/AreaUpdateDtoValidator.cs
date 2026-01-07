using FluentValidation;
using FacilityManagementSystem.Application.DTOs.AreaDto;

public class AreaUpdateDtoValidator : AbstractValidator<AreaUpdateDto>
{
    public AreaUpdateDtoValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Area type cannot be empty.")
            .MaximumLength(100).WithMessage("Area type must not exceed 100 characters.");
    }
}
