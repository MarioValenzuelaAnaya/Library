using Xunit;
using Biblioteca.Application.Features.Loan.Querys.GetLoanList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Moq;
using Biblioteca.Application.Mappings;
using Biblioteca.test.Mocks;
using Biblioteca.Application.Features.Books.Querys.GetBooksList;
using Shouldly;

namespace Biblioteca.Application.Features.Loan.Querys.GetLoanList.Tests
{
    public class GetLoandListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILoanRepository> _mockRepo;

        public GetLoandListQueryHandlerTests()
        {
            _mockRepo = MockLoanRepository.GetLoanRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact()]
        public async Task HandleTest()
        {
            var handler = new GetLoandListQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLoandListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<GetLoanList>>();
            var loan =  result.Find(x => x.id == 1);
            loan.ShouldNotBeNull();
            loan.Book.Title.ShouldBe("One Piece");
            result.Count.ShouldBe(3);
        }
    }
}