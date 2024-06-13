using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Books.Commans.DeleteBook
{
    public class DeleteBookCommand : IRequest<string>
    {

        public int Id { get; set; }
    }
}
