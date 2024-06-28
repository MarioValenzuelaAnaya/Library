using FluentValidation;


namespace Biblioteca.Application.Features.Books.Commans.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The title is required.")
                .MaximumLength(100).WithMessage("The title must not exceed 100 characters.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("The author is required.")
                .MaximumLength(100).WithMessage("The author must not exceed 100 characters.");

            RuleFor(x => x.CopiesAvailable)
                .GreaterThanOrEqualTo(0).WithMessage("Copies available must be a non-negative number.");
        }
    }
}
