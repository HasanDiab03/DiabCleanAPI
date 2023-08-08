using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using DiabCleanAPI.Shared;
using DiabCleanAPI.Shared.RequestAbstractions;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Application.Commands.CompanyCommands.Handlers
{
    public class AddEmployeeToCompanyHandler : ICommandHandler<AddEmployeeToCompanyCommand, CompanyDTO>
    {
        private readonly ICompanyRepository companyRepository;
        public AddEmployeeToCompanyHandler(ICompanyRepository companyRepository) 
        {
            this.companyRepository = companyRepository;
        }
        public async Task<Response<CompanyDTO>> Handle(AddEmployeeToCompanyCommand request, CancellationToken cancellationToken)
        {
            var (id, name, address, phone, email) = request;
            var company = await companyRepository.AddEmployeeToCompanyAsync(id, name, address, phone, email);
            return Response.Success(company.Adapt<Company, CompanyDTO>(), "Added Employee to Company Successfully");
        }
    }
}
