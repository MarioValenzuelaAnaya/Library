using Biblioteca.Application.Features.Books.Querys.GetBooksList;
using Biblioteca.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Loan.Querys.GetLoanList
{
    public class GetLoandListQuery : IRequest<List<GetLoanList>>
    {
        public GetLoandListQuery() { }
       
    }



}
