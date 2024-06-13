using Biblioteca.Application.Features.Books.Commans.CreateBook;
using Biblioteca.Application.Features.Books.Commans.DeleteBook;
using Biblioteca.Application.Features.Books.Commans.UpdateBook;
using Biblioteca.Application.Features.Books.Querys.GetBooksList;
using Biblioteca.Application.Features.Loan.Command.AddLoan;
using Biblioteca.Application.Features.Loan.Command.ReturnLoan;
using Biblioteca.Application.Features.Loan.Querys.GetLoanList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]

        public async Task<ActionResult<IEnumerable<GetBooksList>>> GetBooks()
        {
            var query = new GetBooksListQuery();
            var books = await _mediator.Send(query);
            return Ok(books);
        }




        [HttpPost]

        public async Task<ActionResult<string>> CreateBook([FromBody] CreateBookCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteBook(int id)
        {
            var command = new DeleteBookCommand { Id = id };
            return await _mediator.Send(command);





        }
        [HttpPost("UpdateBook")]
        public async Task<ActionResult<string>> UpdateBook(UpdateBookCommand request)
        {

            return await _mediator.Send(request);
        }


        [HttpPost("AddLoan")]

        public async Task<ActionResult<string>> AddLoan([FromBody] AddBookLoanCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("GetLoans")]

        public async Task<ActionResult<IEnumerable<GetLoanList>>> GetLoans()
        {
            var query = new GetLoandListQuery();
            var loans = await _mediator.Send(query);
            return Ok(loans);
        }

        [HttpPost("ReturnLoan")]

        public async Task<ActionResult<string>> ReturnLoan([FromBody] ReturnLoanCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
