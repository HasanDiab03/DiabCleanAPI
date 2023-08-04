using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using MediatR;

namespace DiabCleanAPI.DiabCleanAPI.Application.Queries.EmployeeQueries
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDTO>;
}
