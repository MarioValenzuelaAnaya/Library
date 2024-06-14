using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Domain;
using Moq;

namespace Biblioteca.test.Mocks
{
    public static class MockBookRepository
    {
        public static Mock<IBookRepository> GetBookRepository()
        {
            var books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Harry Potther",
                    Author = "Test Author 1",
                    CopiesAvailable=5
                },
                new Book
                {
                    Id = 2,
                    Title = "One Piece",
                    Author = "Test Author 2",
                    CopiesAvailable=5
                },
                new Book
                {
                    Id = 3,
                    Title = "Mago de oz",
                    Author = "Test Author 3",
                     CopiesAvailable=5
                }
            };

            var mockRepo = new Mock<IBookRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(books);

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Book>())).ReturnsAsync((Book book) =>
            {
                var bookToRemove = books.FirstOrDefault(b => b.Id == book.Id);
                if (bookToRemove != null)
                {
                    books.Remove(bookToRemove);
                    return 1;
                }
                return 0;
            });

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var book = books.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    return book;
                }
                throw new KeyNotFoundException($"Book with id {id} not found.");
            });


            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Book>())).ReturnsAsync((Book book) =>
            {
                var bookToUpdate = books.FirstOrDefault(b => b.Id == book.Id);
                if (bookToUpdate != null)
                {
                    bookToUpdate.Title = book.Title;
                    bookToUpdate.Author = book.Author;
                    return bookToUpdate;
                }
                throw new KeyNotFoundException($"Book with id {book.Id} not found.");
            });


            mockRepo.Setup(r => r.AddAsync(It.IsAny<Book>())).ReturnsAsync((Book book) =>
            {
                books.Add(book);
                return book;
            });

            mockRepo.Setup(r => r.LendBookAsync(It.IsAny<int>())).ReturnsAsync((int bookId) =>
            {

                var loans = new List<Loan>();
                var bookToLend = books.FirstOrDefault(b => b.Id == bookId);
                if (bookToLend != null && bookToLend.CopiesAvailable > 0)
                {
                    bookToLend.CopiesAvailable--;

                    var loan = new Loan
                    {
                        BookId = bookToLend.Id,
                        LoanDate = DateTime.Now,
                        Book = bookToLend,
                        IsBorrowed = true
                    };
                    loans.Add(loan);

                    return loan.Book.Title;
                }
                throw new InvalidOperationException("Book not available for lending.");
            });



            return mockRepo;
        }
    }
}
