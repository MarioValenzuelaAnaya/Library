using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Mappings;
using Biblioteca.test.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace Biblioteca.Application.Features.Books.Commans.UpdateBook.Tests
{
    public class UpdateBookCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBookRepository> _mockRepo;
        private readonly UpdateBookCommand _updateBookCommand;
        private readonly UpdateBookCommandHandler _handler;
        private readonly Mock<ILogger<UpdateBookCommandHandler>> _mockLogger;

        public UpdateBookCommandHandlerTests()
        {
            _mockRepo = MockBookRepository.GetBookRepository();
            _mockLogger = new Mock<ILogger<UpdateBookCommandHandler>>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdateBookCommandHandler(_mockRepo.Object, _mapper, _mockLogger.Object);

            _updateBookCommand = new UpdateBookCommand
            {
                Id = 3,
                Title = "Mago de oz update",
                Author = "Test Author 3",
                CopiesAvailable=5,
               
            };
        }

        [Fact]
        public async Task HandleTest()
        {
         
            var result = await _handler.Handle(_updateBookCommand, CancellationToken.None);

         
            result.ShouldBe(_updateBookCommand.Title);

            var updatedBook = await _mockRepo.Object.GetByIdAsync(_updateBookCommand.Id);
            updatedBook.ShouldNotBeNull();
            updatedBook.Title.ShouldBe(_updateBookCommand.Title);
            updatedBook.Author.ShouldBe(_updateBookCommand.Author);
            updatedBook.CopiesAvailable.ShouldBe(_updateBookCommand.CopiesAvailable);
         
        }
    }
}