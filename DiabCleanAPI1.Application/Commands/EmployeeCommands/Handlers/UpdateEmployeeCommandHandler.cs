using DiabCleanAPI;
using DiabCleanAPI.DiabCleanAPI.Application.Commands.EmployeeCommands;
using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using Mapster;
using MediatR;

namespace Diab_Employee.DiabCleanAPI.Application.Commands.EmployeeCommands.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeeRepository employeeRepository;
        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDTO> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var (id, name, address, phone, email) = request;
            var update = await employeeRepository.GetByIdAsync(id);
            update.Update(name, address, phone, email);
            var updated = await employeeRepository.UpdateAsync(update);
            return updated.Adapt<Employee, EmployeeDTO>();
        }
    }
}
