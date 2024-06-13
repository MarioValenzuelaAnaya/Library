using AutoMapper;
using Biblioteca.Application.Features.Books.Commans.CreateBook;
using Biblioteca.Application.Features.Books.Commans.UpdateBook;
using Biblioteca.Application.Features.Books.Querys.GetBooksList;
using Biblioteca.Application.Features.Loan.Querys.GetLoanList;
using Biblioteca.Domain;

namespace Biblioteca.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Book, GetBooksList>();
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<Loan, GetLoanList>()
              .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book));

            CreateMap<Book, BookDto>();
        }
    }
}
