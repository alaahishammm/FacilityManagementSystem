using FluentValidation;
using FacilityManagementSystem.Application.DTOs.AssetDto;

namespace FacilityManagementSystem.Application.Validators.Asset
{
    public class AssetUpdateDtoValidator : AbstractValidator<AssetUpdateDto>
    {
        public AssetUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .When(x => x.Name != null);

            RuleFor(x => x.SerialNumber)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Category)
                .NotEmpty()
                .MaximumLength(50)
                .When(x => x.Category != null);

            RuleFor(x => x.FacilityId)
                .GreaterThan(0)
                .When(x => x.FacilityId.HasValue)
                .WithMessage("FacilityId must be a valid id");

            RuleFor(x => x.AreaId)
                .GreaterThan(0)
                .When(x => x.AreaId.HasValue)
                .WithMessage("AreaId must be a valid id");
        }
    }
}
