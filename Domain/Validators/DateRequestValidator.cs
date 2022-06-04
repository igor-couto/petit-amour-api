using FluentValidation;
using PetitAmourAPI.Domain.Requests;

namespace PetitAmourAPI.Domain.Validators
{
    public class DateRequestValidator : AbstractValidator<DateRequest>
    {
        public DateRequestValidator()
        {
            var currentDate = DateTime.Now;

            RuleFor(x => x.Day)
                .NotEmpty()
                .GreaterThanOrEqualTo(currentDate.Day);

            RuleFor(x => x.Month)
                .NotEmpty()
                .GreaterThanOrEqualTo(currentDate.Month);

            RuleFor(x => x.Year)
                .NotEmpty()
                .GreaterThanOrEqualTo(currentDate.Year);
        }
    }
}