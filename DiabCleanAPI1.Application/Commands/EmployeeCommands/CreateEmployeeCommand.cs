using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.Shared.RequestAbstractions;
using MediatR;


namespace DiabCleanAPI.DiabCleanAPI.Application.Commands.EmployeeCommands
{
    public record CreateEmployeeCommand(string Name, string Address, string Phone, string Email) : ICommand<EmployeeDTO>;
}
