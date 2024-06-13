using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Domain;
using Biblioteca.Infrastructure.Infrastructure;

namespace Biblioteca.Infrastructure.Repositoies
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        private readonly ILoanRepository _loanRepository;

        public BookRepository(DatabaseContext context, ILoanRepository loanRepository) : base(context)
        {
            _loanRepository = loanRepository;
        }

        public async Task<string> LendBookAsync(int bookId)
        {
            var book = await GetByIdAsync(bookId); 

            if (book == null || book.CopiesAvailable <= 0)
            {
                throw new InvalidOperationException("Book not available for lending.");
            }

            book.CopiesAvailable--;
            await UpdateAsync(book); 

            var loan = new Loan
            {
                BookId = bookId,
                LoanDate = DateTime.Now,
                Book=book,
                IsBorrowed = true,
            };

             var result=   await _loanRepository.AddAsync(loan);
           
            return result.Book.Title;
        }
    }
}
