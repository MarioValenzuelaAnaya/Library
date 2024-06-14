using Xunit;
using Biblioteca.Application.Features.Loan.Command.AddLoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Features.Books.Commans.CreateBook;
using Microsoft.Extensions.Logging;
using Moq;
using Biblioteca.Application.Mappings;
using Biblioteca.Test;
using Shouldly;

namespace Biblioteca.Application.Features.Loan.Command.AddLoan.Tests
{
    public class AddBookLoanCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IBookRepository> _mockRepo;
        private readonly AddBookLoanCommand _createBookCommand;
        private readonly AddBookLoanCommandHandler _handler;
        private readonly Mock<ILogger<AddBookLoanCommandHandler>> _mockLogger;


        public AddBookLoanCommandHandlerTest()
        {
            _mockRepo = MockBookRepository.GetBookRepository();
            _mockLogger = new Mock<ILogger<AddBookLoanCommandHandler>>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new AddBookLoanCommandHandler(_mockRepo.Object, _mapper, _mockLogger.Object);

            _createBookCommand = new AddBookLoanCommand
            {
                BookId=1
                

            };
        }



        [Fact()]
        public async Task HandleTest()
        {
            var result = await _handler.Handle(_createBookCommand,CancellationToken.None);

            result.ShouldBe("Harry Potther");
        }
    }
}