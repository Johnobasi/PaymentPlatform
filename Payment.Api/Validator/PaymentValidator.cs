using FluentValidation;
using Payment.Api.Dto;
using System;

namespace Payment.Api.Validator
{
    public class PaymentValidator: AbstractValidator<TransactionPaymentDto>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.CreditCardNumber).NotEmpty().WithMessage("Credit card cannot be empty")
                .NotNull()
                .WithMessage("Credit card cannot be null")
                .MinimumLength(12)
                .MaximumLength(19)
                .CreditCard()
                .WithMessage("Please input a valid credit card");
            RuleFor(x => x.CardHolder)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.ExpirationDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(e => DateTime.Now);
            RuleFor(x => x.SecurityCode).MaximumLength(3);
            RuleFor(x => x.Amount)
                .NotEmpty()
                .NotNull()
                .GreaterThan(e => 0);

        }
    }
}
