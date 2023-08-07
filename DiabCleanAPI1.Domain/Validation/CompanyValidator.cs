
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Domain.Validation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator() 
        {
            RuleFor(company => company.Name)
                .NotEmpty()
                .WithMessage("Company name is required");
            RuleFor(company => company.Field)
                .NotEmpty()
                .WithMessage("Company Field is required")
                .MaximumLength(50)
                .WithMessage("Field cannot exceed 50 characters");
        }
    }
}
