using FluentValidation;


namespace Biblioteca.Application.Features.Books.Commans.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("The Id must be greater than 0.");

            RuleFor(x => x.CopiesAvailable)
                .GreaterThanOrEqualTo(0).WithMessage("Copies available must be a non-negative number.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The title is required.")
                .MaximumLength(100).WithMessage("The title must not exceed 100 characters.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("The author is required.")
                .MaximumLength(100).WithMessage("The author must not exceed 100 characters.");
        }
    }
}
