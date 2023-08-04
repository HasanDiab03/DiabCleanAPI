using MediatR;

namespace DiabCleanAPI.Application.Commands.EmployeeCommands
{
    public record DeleteEmployeeCommand(int id) : IRequest<Unit>;
}
