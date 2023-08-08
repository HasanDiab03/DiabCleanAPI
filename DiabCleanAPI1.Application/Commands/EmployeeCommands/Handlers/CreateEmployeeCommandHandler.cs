using DiabCleanAPI;
using DiabCleanAPI.DiabCleanAPI.Application.Commands.EmployeeCommands;
using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using DiabCleanAPI.Shared;
using DiabCleanAPI.Shared.RequestAbstractions;
using FluentValidation;
using Mapster;
using MediatR;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace Diab_Employee.DiabCleanAPI.Application.Commands.EmployeeCommands.Handlers
{
    public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IValidator<Employee> validator;
        public CreateEmployeeCommandHandler(IValidator<Employee> validator, IEmployeeRepository employeeRepository)
        {
            this.validator = validator;
            this.employeeRepository = employeeRepository;
        }
        public async Task<Response<EmployeeDTO>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var (Name, Address, Phone, Email) = request;
            var employee = new Employee(Name, Address, Phone, Email);
            var validate = await validator.ValidateAsync(employee);
            if(!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            var added = await employeeRepository.AddAsync(employee);
            return Response.Success(added.Adapt<Employee, EmployeeDTO>(), "added employee");
        }
    }
}
