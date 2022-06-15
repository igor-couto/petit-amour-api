using FluentValidation;

namespace PetitAmourAPI.Domain.Validators
{
    public class DateRequestValidator : AbstractValidator<DateRequest>
    {
        public DateRequestValidator()
        {
            var currentDate = DateTime.Now;

            RuleFor(x => x.Date)
                .NotEmpty()
                .GreaterThanOrEqualTo(currentDate);
        }
    }
}