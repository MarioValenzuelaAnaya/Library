using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using MediatR;

namespace Biblioteca.Application.Features.Books.Querys.GetBooksList
{
    public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, List<GetBooksList>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _Mapper;
        

        public GetBooksListQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _Mapper = mapper;
        }

        public async Task<List<GetBooksList>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
        {
            var booksVM = await _bookRepository.GetAllAsync();
            return _Mapper.Map<List<GetBooksList>>(booksVM);
        }
    }
}
