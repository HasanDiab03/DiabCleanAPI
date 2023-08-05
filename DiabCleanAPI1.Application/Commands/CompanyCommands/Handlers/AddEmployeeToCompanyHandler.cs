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
    public class AddEmployeeToCompanyHandler : IRequestHandler<AddEmployeeToCompanyCommand, CompanyDTO>
    {
        private readonly ICompanyRepository companyRepository;
        public AddEmployeeToCompanyHandler(ICompanyRepository companyRepository) 
        {
            this.companyRepository = companyRepository;
        }
        public async Task<CompanyDTO> Handle(AddEmployeeToCompanyCommand request, CancellationToken cancellationToken)
        {
            var (id, name, address, phone, email) = request;
            var company = await companyRepository.AddEmployeeToCompanyAsync(id, name, address, phone, email);
            return company.Adapt<Company, CompanyDTO>();
        }
    }
}
