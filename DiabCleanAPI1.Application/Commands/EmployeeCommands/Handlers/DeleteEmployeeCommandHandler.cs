using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using DiabCleanAPI.Shared;
using DiabCleanAPI.Shared.RequestAbstractions;
using MediatR;

namespace DiabCleanAPI.Application.Commands.EmployeeCommands.Handlers
{
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository employeeRepository;
        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<Response<Unit>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await employeeRepository.DeleteAsync(request.id);
            return Response.Success(Unit.Value, "deleted employee");
        }
    }
}
