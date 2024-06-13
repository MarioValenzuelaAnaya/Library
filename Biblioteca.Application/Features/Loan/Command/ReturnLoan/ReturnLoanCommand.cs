using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Loan.Command.ReturnLoan
{
    public class ReturnLoanCommand : IRequest<string>
    {
        public int loanId { get; set; }
    }
}
