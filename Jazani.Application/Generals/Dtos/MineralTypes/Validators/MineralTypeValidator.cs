using FluentValidation;

namespace Jazani.Application.Generals.Dtos.MineralTypes.Validators
{
	public class MineralTypeValidator : AbstractValidator<MineralTypeSaveDto> 
	{
		public MineralTypeValidator()
		{
			RuleFor(x => x.Name)
				//.NotNull().WithMessage("Name required")
                    .Length(1, 250)
					.WithMessage("Name should be between 10 and 15 chars");

        }
	}
}

