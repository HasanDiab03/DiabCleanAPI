
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Domain.Validation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator() 
        { 
            RuleFor(employee => employee.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
            RuleFor(employee => employee.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email formay");
        }
    }
}
