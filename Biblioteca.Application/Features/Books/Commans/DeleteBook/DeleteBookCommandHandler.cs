using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using Biblioteca.Application.Features.Books.Commans.CreateBook;
using Biblioteca.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Books.Commans.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, string>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteBookCommandHandler> _logger;

        public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILogger<DeleteBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var BookToDelete = await _bookRepository.GetByIdAsync(request.Id);
            if (BookToDelete == null)
            {
                _logger.LogError($"{request.Id} Book does not exist in the system");
                throw new NotFoundException(nameof(Book), request.Id);
            }
           var BookName= BookToDelete.Title;
            await _bookRepository.DeleteAsync(BookToDelete);

            _logger.LogInformation($"the book with id {request.Id} deleted");

            return BookName;
        }
    }
}
