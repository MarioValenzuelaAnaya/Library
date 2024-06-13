using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Features.Loan.Command.AddLoan
{
    public class AddBookLoanCommandHandler : IRequestHandler<AddBookLoanCommand, string>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddBookLoanCommandHandler> _logger;

        public AddBookLoanCommandHandler(IBookRepository bookRepository, IMapper mapper, ILogger<AddBookLoanCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(AddBookLoanCommand request, CancellationToken cancellationToken)
        {
           var result =await _bookRepository.LendBookAsync(request.BookId);
            _logger.LogInformation($"Book {result} loaned");

            return result;
           
        }
    }
}
