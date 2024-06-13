using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Books.Commans.UpdateBook
{
    public class UpdateBookCommand : IRequest<string>
    {

        public int Id { get; set; }
        public int CopiesAvailable { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsBorrowed { get; set; }
    }
}
