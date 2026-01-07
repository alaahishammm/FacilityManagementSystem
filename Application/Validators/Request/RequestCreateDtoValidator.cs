using FluentValidation;
using FacilityManagementSystem.Application.DTOs.RequestDto;

namespace FacilityManagementSystem.Application.Validators.Request
{
    public class RequestCreateDtoValidator : AbstractValidator<RequestCreateDto>
    {
        public RequestCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(150);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500);

            RuleFor(x => x.FacilityId)
                .GreaterThan(0)
                .WithMessage("FacilityId must be a valid id");

            RuleFor(x => x.CreatedById)
                .GreaterThan(0)
                .WithMessage("CreatedById must be a valid user id");

            RuleFor(x => x.AreaId)
                .GreaterThan(0)
                .When(x => x.AreaId.HasValue)
                .WithMessage("AreaId must be a valid id");

            RuleFor(x => x.AssetId)
                .GreaterThan(0)
                .When(x => x.AssetId.HasValue)
                .WithMessage("AssetId must be a valid id");

            // Optional: لازم يبقى في Facility + (Area أو Asset)
            RuleFor(x => x)
                .Must(x => x.AreaId.HasValue || x.AssetId.HasValue)
                .WithMessage("Either AreaId or AssetId must be provided");
        }
    }
}
