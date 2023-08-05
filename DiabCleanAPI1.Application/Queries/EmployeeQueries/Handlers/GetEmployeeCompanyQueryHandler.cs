using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Application.Queries.EmployeeQueries.Handlers
{
    public class GetEmployeeCompanyQueryHandler : IRequestHandler<GetEmployeeCompanyQuery, CompanyDTO>
    {
        private readonly IEmployeeRepository employeeRepository;
        public GetEmployeeCompanyQueryHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<CompanyDTO?> Handle(GetEmployeeCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await employeeRepository.GetEmployeeCompany(request.id);
            return company?.Adapt<Company, CompanyDTO>();
        }
    }
}
