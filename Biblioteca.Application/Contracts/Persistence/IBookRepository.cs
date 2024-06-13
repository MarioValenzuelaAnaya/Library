using Biblioteca.Domain;

namespace Biblioteca.Application.Contracts.Persistence
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
        Task <string>LendBookAsync(int bookId);
    }
}
