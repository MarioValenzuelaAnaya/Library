using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Mappings;
using Biblioteca.test.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace Biblioteca.Application.Features.Books.Commans.CreateBook.Tests
{
    public class CreateBookCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBookRepository> _mockRepo;
        private readonly CreateBookCommand _createBookCommand;
        private readonly CreateBookCommandHandler _handler;
        private readonly Mock<ILogger<CreateBookCommandHandler>> _mockLogger;



        public CreateBookCommandHandlerTests()
        {
            _mockRepo = MockBookRepository.GetBookRepository();
            _mockLogger = new Mock<ILogger<CreateBookCommandHandler>>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateBookCommandHandler(_mockRepo.Object, _mapper, _mockLogger.Object);

            _createBookCommand = new CreateBookCommand
            {
          
                Title = "Got",
                Author = "Test Author create",
                CopiesAvailable = 5,

            };
        }



        [Fact()]
        public async Task CreateBookCommandHandlerTest()
        {
            var result = await _handler.Handle(_createBookCommand,CancellationToken.None);

            result.ShouldBe(_createBookCommand.Title);
        }

       
    }
}