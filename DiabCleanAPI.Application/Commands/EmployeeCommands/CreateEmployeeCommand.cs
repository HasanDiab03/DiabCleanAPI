using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using MediatR;


namespace DiabCleanAPI.DiabCleanAPI.Application.Commands.EmployeeCommands
{
    public record CreateEmployeeCommand(string Name, string Address, string Phone, string Email) : IRequest<EmployeeDTO>;
}
