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
    public class RemoveEmployeeFromCompanyHandler : ICommandHandler<RemoveEmployeeFromCompanyCommand, CompanyDTO>
    {
        private readonly ICompanyRepository companyRepository;
        public RemoveEmployeeFromCompanyHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public async Task<Response<CompanyDTO>> Handle(RemoveEmployeeFromCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await companyRepository.RemoveEmployeeFromCompanyAsync(request.companyId, request.employeeId);
            return Response.Success(company.Adapt<Company, CompanyDTO>(), "Succesfully remove employee from company");
        }
    }
}
