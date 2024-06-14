using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Mappings;
using Biblioteca.test.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace Biblioteca.Application.Features.Loan.Command.ReturnLoan.Tests
{
    public class ReturnLoandCommanHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILoanRepository> _mockRepo;
        private readonly ReturnLoanCommand _ReturnLoanCommand;
        private readonly ReturnLoandCommanHandler _handler;
        private readonly Mock<ILogger<ReturnLoandCommanHandler>> _mockLogger;


        public ReturnLoandCommanHandlerTests()
        {
            _mockRepo = MockLoanRepository.GetLoanRepository();
            _mockLogger = new Mock<ILogger<ReturnLoandCommanHandler>>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new ReturnLoandCommanHandler(_mockRepo.Object, _mapper, _mockLogger.Object);

            _ReturnLoanCommand = new ReturnLoanCommand
            {
                loanId = 1
            };
        }


        [Fact()]
        public async Task HandleTest()
        {
            var loan = _mockRepo.Object.GetByIdAsync(_ReturnLoanCommand.loanId);

            if (loan != null) 
            {
                var result = await _handler.Handle(_ReturnLoanCommand, CancellationToken.None);
                result.ShouldBe("One Piece");
            }
           

          await  loan.ShouldNotBeNull();
        }
    }
}