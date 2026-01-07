using FluentValidation;
using FacilityManagementSystem.Application.DTOs.WorkOrderDto;

namespace FacilityManagementSystem.Application.Validators.WorkOrder
{
    public class WorkOrderCreateDtoValidator : AbstractValidator<WorkOrderCreateDto>
    {
        public WorkOrderCreateDtoValidator()
        {
            RuleFor(x => x.RequestId)
                .GreaterThan(0)
                .WithMessage("RequestId must be a valid id");

            RuleFor(x => x.TechnicianId)
                .GreaterThan(0)
                .WithMessage("TechnicianId must be a valid id");

            RuleFor(x => x.TechnicianName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.AssignedAt)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("AssignedAt cannot be in the future");

            RuleFor(x => x.Notes)
                .MaximumLength(500)
                .When(x => x.Notes != null);
        }
    }
}
