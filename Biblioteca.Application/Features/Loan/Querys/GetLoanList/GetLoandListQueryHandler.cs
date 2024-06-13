using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using MediatR;

namespace Biblioteca.Application.Features.Loan.Querys.GetLoanList
{
    public class GetLoandListQueryHandler : IRequestHandler<GetLoandListQuery, List<GetLoanList>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _Mapper;

        public GetLoandListQueryHandler(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _Mapper = mapper;
        }

        public async Task<List<GetLoanList>> Handle(GetLoandListQuery request, CancellationToken cancellationToken)
        {

         
            var loans = await _loanRepository.GetAsync(predicate: loan => loan.IsBorrowed==true, includeString: "Book");

            return _Mapper.Map<List<GetLoanList>>(loans);
        }
    }
}
