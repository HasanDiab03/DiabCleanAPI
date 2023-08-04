using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiabCleanAPI.DiabCleanAPI.Application.Queries.EmployeeQueries.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {
        private readonly IEmployeeRepository employeeRepository;
        public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository) 
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await employeeRepository.GetByIdAsync(request.Id);
            return employee.Adapt<Employee, EmployeeDTO>();
        }
    }
}
