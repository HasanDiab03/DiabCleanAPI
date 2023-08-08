using DiabCleanAPI.Shared.RequestAbstractions;
using MediatR;
using System.Windows.Input;

namespace DiabCleanAPI.Application.Commands.EmployeeCommands
{
    public record DeleteEmployeeCommand(int id) : ICommand<Unit>;
}
