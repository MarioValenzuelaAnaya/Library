using FluentValidation;


namespace Biblioteca.Application.Features.Loan.Command.AddLoan
{
    public class AddBookLoanCommandValidator : AbstractValidator<AddBookLoanCommand>
    {
        public AddBookLoanCommandValidator()
        {
            RuleFor(x => x.BookId)
                .GreaterThan(0).WithMessage("BookId must be greater than 0.");
        }
    }
}
