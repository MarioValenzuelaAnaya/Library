using MediatR;

namespace Biblioteca.Application.Features.Loan.Command.AddLoan
{
    public class AddBookLoanCommand : IRequest<string>
    {
        public int BookId { get; set; }

    }
}
