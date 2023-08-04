using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using MediatR;

namespace DiabCleanAPI.Application.Commands.EmployeeCommands.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository employeeRepository;
        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await employeeRepository.DeleteAsync(request.id);
            return Unit.Value;
        }
    }
}
