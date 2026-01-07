using FluentValidation;
using FacilityManagementSystem.Application.DTOs.WorkOrderDto;

namespace FacilityManagementSystem.Application.Validators.WorkOrder
{
    public class WorkOrderUpdateDtoValidator : AbstractValidator<WorkOrderUpdateDto>
    {
        public WorkOrderUpdateDtoValidator()
        {
            RuleFor(x => x.TechnicianId)
                .GreaterThan(0)
                .WithMessage("TechnicianId must be a valid id");

            RuleFor(x => x.Status)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Note)
                .MaximumLength(500)
                .When(x => x.Note != null);
        }
    }
}
