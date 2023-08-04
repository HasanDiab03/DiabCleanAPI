using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using MediatR;

namespace DiabCleanAPI.DiabCleanAPI.Application.Commands.EmployeeCommands
{
    public record UpdateEmployeeCommand(int id, string name, string address, string phone, string email) : IRequest<EmployeeDTO>;
}
