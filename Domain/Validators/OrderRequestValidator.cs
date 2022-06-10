using FluentValidation;
using PetitAmourAPI.Domain.Requests;

namespace PetitAmourAPI.Domain.Validators
{
    public class OrderRequestValidator : AbstractValidator<OrderRequest>
    {
        public OrderRequestValidator()
        {
            var currentDate = DateTime.Now;

            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(x => x.CustomerPhoneNumber)
                .NotEmpty()
                .MaximumLength(16);

            RuleFor(x => x.PaymentMethod)
                .InclusiveBetween((short)0, (short)3);

            RuleFor(x => x.DeliveryDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(currentDate);

            RuleFor(x => x.DeliveryAddress)
                .NotEmpty()
                .MaximumLength(512);

            RuleFor(x => x.productRequest)
                .NotEmpty();
        }
    }
}