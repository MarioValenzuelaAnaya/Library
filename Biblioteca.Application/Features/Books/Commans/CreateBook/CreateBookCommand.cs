using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Books.Commans.CreateBook
{
    public class CreateBookCommand : IRequest<string>
    {


        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int CopiesAvailable { get; set; }
    }

}
