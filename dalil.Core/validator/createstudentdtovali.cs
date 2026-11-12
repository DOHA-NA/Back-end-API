using FluentValidation;
using ApiCe.Core.Students;

namespace ApiCe.Core.Validators
{
    public class CreateSTDDtoValidator : AbstractValidator<CreateSTDDto>
    {
        public CreateSTDDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name is required").MaximumLength(100).WithMessage("Full name cannot exceed 100 characters");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format").MaximumLength(100);
        }
    }
}