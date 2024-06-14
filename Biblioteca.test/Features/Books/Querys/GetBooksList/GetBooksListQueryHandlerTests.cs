using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Mappings;
using Biblioteca.test;
using Biblioteca.test.Mocks;
using Moq;
using Shouldly;

namespace Biblioteca.Application.Features.Books.Querys.GetBooksList.Tests
{
    public class GetBooksListQueryHandlerTests
    {


        private readonly IMapper _mapper;
        private readonly Mock<IBookRepository> _mockRepo;
        public GetBooksListQueryHandlerTests()
        {
            _mockRepo = MockBookRepository.GetBookRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetBooksListQueryHandlerTest()
        {
            var handler = new GetBooksListQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetBooksListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<GetBooksList>>();

            result.Count.ShouldBe(3);

        }
    }

    }
