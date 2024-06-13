using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Loan.Querys.GetLoanList
{
    public class GetLoanList
    {
        public int id { get; set; }
        public int BookId { get; set; }
        public BookDto Book { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsBorrowed { get; set; }
    }

    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
