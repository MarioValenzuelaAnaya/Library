using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca.test.Mocks
{
    public static class MockLoanRepository
    {
        public static Mock<ILoanRepository> GetLoanRepository()
        {

            var book = new Book
            {
                Id = 2,
                Title = "One Piece",
                Author = "Test Author 2",
                CopiesAvailable = 5
                

            };

            var loans = new List<Loan>
            {
                new Loan
                {
                    Id = 1,
                    BookId = 2,
                    Book=book,
                    LoanDate = DateTime.Now,
                    IsBorrowed = true,
                },
                new Loan
                {
                    Id = 2,
                    BookId = 2,
                    Book=book,
                    LoanDate = DateTime.Now,
                      IsBorrowed = true,
                },
                new Loan
                {
                    Id = 3,
                    BookId = 2,
                    Book=book,
                    LoanDate = DateTime.Now,
                      IsBorrowed = true,
                }
            };





            var mockRepo = new Mock<ILoanRepository>();

            mockRepo.Setup(r => r.GetAsync(
                          It.IsAny<Expression<Func<Loan, bool>>>(),
                          It.IsAny<Func<IQueryable<Loan>, IOrderedQueryable<Loan>>>(),
                          It.IsAny<string>(),
                          It.IsAny<bool>()
                                          )).ReturnsAsync((Expression<Func<Loan, bool>> predicate,
                                          Func<IQueryable<Loan>, IOrderedQueryable<Loan>> orderBy,
                                          string includeString,
                                          bool disableTracking) =>
                                             {
                                              var query = loans.AsQueryable();

                                              if (predicate != null)
                                              {
                                                  query = query.Where(predicate);
                                              }

                                              return query.ToList().AsReadOnly();
                                                           });


            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var loan = loans.FirstOrDefault(b => b.Id == id);
                if (loan != null)
                {
                    return loan;
                }
                throw new KeyNotFoundException($"loan with id {id} not found.");
            });


            mockRepo.Setup(r => r.ReturnLoanAsync(It.IsAny<int>())).Returns((int id) =>
            {
                var loanToReturn = loans.FirstOrDefault(b => b.Id == id);
                if (loanToReturn != null)
                {

                    loanToReturn.ReturnDate = DateTime.Now;
                    loanToReturn.IsBorrowed = false;
                    var bookToUpdate = loanToReturn.Book;
                    bookToUpdate.CopiesAvailable++;
                    return Task.FromResult(bookToUpdate.Title);
                }
                throw new InvalidOperationException("Loan not available for return.");
            });





            return mockRepo;
        }

    }
}
