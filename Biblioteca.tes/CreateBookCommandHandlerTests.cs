using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Features.Books.Commans.CreateBook;
using Biblioteca.Domain;
using Microsoft.Extensions.Logging;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Biblioteca.tes
{
    public class CreateBookCommandHandlerTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<CreateBookCommandHandler>> _mockLogger;
        private readonly CreateBookCommandHandler _handler;

        public CreateBookCommandHandlerTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateBookCommand, Book>();
            });

            _mapper = configurationProvider.CreateMapper();
            _mockLogger = new Mock<ILogger<CreateBookCommandHandler>>();

            _handler = new CreateBookCommandHandler(_mockBookRepository.Object, _mapper, _mockLogger.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsBookTitle()
        {
            // Arrange
            var command = new CreateBookCommand
            {
                Title = "Test Book",
                Author = "Test Author",
                CopiesAvailable = 5
            };

            var book = new Book
            {
                Id = 1,
                Title = "Test Book",
                Author = "Test Author",
                CopiesAvailable = 5
            };

            _mockBookRepository.Setup(repo => repo.AddAsync(It.IsAny<Book>())).ReturnsAsync(book);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(book.Title, result);
            _mockBookRepository.Verify(repo => repo.AddAsync(It.IsAny<Book>()), Times.Once);
            _mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task Handle_EmptyTitle_ThrowsValidationException()
        {
            // Arrange
            var command = new CreateBookCommand
            {
                Title = "",
                Author = "Test Author",
                CopiesAvailable = 5
            };

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
