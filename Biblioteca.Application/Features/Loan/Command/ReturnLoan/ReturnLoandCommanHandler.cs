using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Features.Books.Commans.CreateBook;
using Biblioteca.Application.Features.Loan.Command.AddLoan;
using Biblioteca.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Loan.Command.ReturnLoan
{
    public class ReturnLoandCommanHandler : IRequestHandler<ReturnLoanCommand, string>
    {
        private readonly ILoanRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ReturnLoandCommanHandler> _logger;

        public ReturnLoandCommanHandler(ILoanRepository bookRepository, IMapper mapper, ILogger<ReturnLoandCommanHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
        {
           var result =await _bookRepository.ReturnLoanAsync(request.loanId);
            _logger.LogInformation($"Book {result} returned");

            return result;
        }
    }
}
