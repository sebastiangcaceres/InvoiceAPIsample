using FluentValidation;
using InvoiceAPIsample.Models;

namespace InvoiceAPIsample.Validators
{
    public class InvoiceValidator : AbstractValidator<Invoices>
    {
        public InvoiceValidator()
        {
            RuleFor(i => i.Customer)
                .NotEmpty()
                .Length(3, 150);

            RuleFor(i => i.Currency)
                .NotEmpty()
                .Length(3);

        }
    }
}
