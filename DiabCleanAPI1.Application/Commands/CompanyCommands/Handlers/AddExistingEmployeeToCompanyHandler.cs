using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Application.Commands.CompanyCommands.Handlers
{
    public class AddExistingEmployeeToCompanyHandler : IRequestHandler<AddExistingEmployeeToCompanyCommand, CompanyDTO>
    {
        private readonly ICompanyRepository companyRepository;
        public AddExistingEmployeeToCompanyHandler(ICompanyRepository companyRepository)
        {
                this.companyRepository = companyRepository;
        }

        public async Task<CompanyDTO> Handle(AddExistingEmployeeToCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await companyRepository.AddExistingEmployeeToCompany(request.companyId, request.employeeId);
            return company.Adapt<Company, CompanyDTO>();
        }
    }
}
