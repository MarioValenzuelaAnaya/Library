using Xunit;
using Biblioteca.Application.Features.Books.Commans.DeleteBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Features.Books.Commans.UpdateBook;
using Microsoft.Extensions.Logging;
using Moq;
using Biblioteca.Application.Mappings;
using Biblioteca.Test;
using Shouldly;

namespace Biblioteca.Application.Features.Books.Commans.DeleteBook.Tests
{
    public class DeleteBookCommandHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IBookRepository> _mockRepo;
        private readonly DeleteBookCommand _deleteBookCommand;
        private readonly DeleteBookCommandHandler _handler;
        private readonly Mock<ILogger<DeleteBookCommandHandler>> _mockLogger;

        public DeleteBookCommandHandlerTests()
        {
            _mockRepo = MockBookRepository.GetBookRepository();
            _mockLogger = new Mock<ILogger<DeleteBookCommandHandler>>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteBookCommandHandler(_mockRepo.Object, _mapper, _mockLogger.Object);

            _deleteBookCommand = new DeleteBookCommand
            {
               Id = 1,

            };
        }

        [Fact]
        public async Task HandleTest()
        {

            var bookToDelete = await _mockRepo.Object.GetByIdAsync(_deleteBookCommand.Id);

            if (bookToDelete != null)
            {  
                var result = await _handler.Handle(_deleteBookCommand, CancellationToken.None);
                result.ShouldBe(bookToDelete.Title);
                result.ShouldNotBeNull();
            }
          


        }
    }
}