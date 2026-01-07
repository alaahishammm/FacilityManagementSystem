using FluentValidation;
using FacilityManagementSystem.Application.DTOs.AssetDto;

namespace FacilityManagementSystem.Application.Validators.Asset
{
    public class AssetCreateDtoValidator : AbstractValidator<AssetCreateDto>
    {
        public AssetCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Asset name is required")
                .MaximumLength(100);

            RuleFor(x => x.SerialNumber)
                .NotEmpty().WithMessage("Serial number is required")
                .MaximumLength(50);

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required")
                .MaximumLength(50);

            RuleFor(x => x.InstalledAt)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Installed date cannot be in the future");

            RuleFor(x => x.FacilityId)
                .GreaterThan(0)
                .WithMessage("FacilityId must be a valid id");

            RuleFor(x => x.AreaId)
                .GreaterThan(0)
                .When(x => x.AreaId.HasValue)
                .WithMessage("AreaId must be a valid id");
        }
    }
}
