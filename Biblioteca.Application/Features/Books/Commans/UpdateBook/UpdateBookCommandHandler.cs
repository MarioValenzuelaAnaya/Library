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

namespace Biblioteca.Application.Features.Books.Commans.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, string>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBookCommandHandler> _logger;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILogger<UpdateBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
           
          var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
            {
                _logger.LogError($"not found {request.Id}");
                throw new NotFoundException(nameof(Book), request.Id);
            }
            _mapper.Map(request, book);
             var result= await _bookRepository.UpdateAsync(book);
           
                return result.Title;
            
         
        }
    }
}
