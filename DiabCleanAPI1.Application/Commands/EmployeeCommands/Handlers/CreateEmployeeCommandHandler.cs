using DiabCleanAPI;
using DiabCleanAPI.DiabCleanAPI.Application.Commands.EmployeeCommands;
using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using Mapster;
using MediatR;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace Diab_Employee.DiabCleanAPI.Application.Commands.EmployeeCommands.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeeRepository employeeRepository;
        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDTO> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var (Name, Address, Phone, Email) = request;
            var employee = new Employee(Name, Address, Phone, Email);
            var added = await employeeRepository.AddAsync(employee);
            return added.Adapt<Employee, EmployeeDTO>();
        }
    }
}
