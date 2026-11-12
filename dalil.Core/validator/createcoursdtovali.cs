using System.Collections.Generic;
using ApiCe.Core.Entites;
using ApiCe.Core.courses;
using FluentValidation;

namespace dalil.Core.validator
{
    public class createcoursdtovali :AbstractValidator<CreateCourseDto>

    {
        public createcoursdtovali()
        {
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("price most be zero and more");
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x =>x.InstructorId).GreaterThan(0);
        }
    }
}