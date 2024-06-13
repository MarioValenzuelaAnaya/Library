using MediatR;

namespace Biblioteca.Application.Features.Books.Querys.GetBooksList
{
    public class GetBooksListQuery:IRequest<List<GetBooksList>>
    {

        public GetBooksListQuery() { }


    }
}
