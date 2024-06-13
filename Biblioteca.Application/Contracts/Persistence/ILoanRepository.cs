using Biblioteca.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Contracts.Persistence
{
    public interface ILoanRepository : IAsyncRepository<Loan>
    {
        Task <string>ReturnLoanAsync(int loanId);
    }
}
