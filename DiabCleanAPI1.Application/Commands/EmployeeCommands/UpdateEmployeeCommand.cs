using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.Shared.RequestAbstractions;
using MediatR;
using System.Windows.Input;

namespace DiabCleanAPI.DiabCleanAPI.Application.Commands.EmployeeCommands
{
    public record UpdateEmployeeCommand(int id, string name, string address, string phone, string email) : ICommand<EmployeeDTO>;
}
