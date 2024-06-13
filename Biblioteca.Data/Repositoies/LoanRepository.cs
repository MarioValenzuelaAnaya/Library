using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Domain;
using Biblioteca.Infrastructure.Infrastructure;
using Biblioteca.Infrastructure.Repositoies;
using Microsoft.EntityFrameworkCore;

public class LoanRepository : RepositoryBase<Loan>, ILoanRepository
{
   

    public LoanRepository(DatabaseContext context) : base(context)
    {
       
    }

    public async Task<string> ReturnLoanAsync(int loanId)
    {
        var loan = await _context.Loans.Include(book=> book.Book).FirstOrDefaultAsync(x=>x.Id==loanId);
    
        if (loan != null)
        {
            var book = loan.Book;
            loan.ReturnDate = DateTime.Now;
            loan.IsBorrowed = false;
            _context.Loans.Update(loan);
            var result = await _context.SaveChangesAsync();

            if (result > 0) 
            {
                book.CopiesAvailable++;
                _context.Books.Update(book);
                _context.SaveChanges();
            }

          
        }else
        {
            throw new InvalidOperationException("Book not available for return.");
        }
        return loan.Book.Title;
    }

    
    
}
