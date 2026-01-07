using FluentValidation;
using FacilityManagementSystem.Application.DTOs.RequestDto;

namespace FacilityManagementSystem.Application.Validators.Request
{
    public class RequestUpdateDtoValidator : AbstractValidator<RequestUpdateDto>
    {
        public RequestUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Invalid request status");
        }
    }
}
