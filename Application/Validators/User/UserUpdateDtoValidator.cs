using FacilityManagementSystem.Application.DTOs.UserDto;
using FluentValidation;

namespace FacilityManagementSystem.Application.Validators.User
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required")
                .MinimumLength(3).WithMessage("Full name must be at least 3 characters");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required");
        }
    }
}
