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
using System.Windows.Input;

namespace DiabCleanAPI.Application.Commands.CompanyCommands.Handlers
{
    public class AddExistingEmployeeToCompanyHandler : ICommandHandler<AddExistingEmployeeToCompanyCommand, CompanyDTO>
    {
        private readonly ICompanyRepository _companyRepository;
        public AddExistingEmployeeToCompanyHandler(ICompanyRepository companyRepository)
        {
                _companyRepository = companyRepository;
        }

        public async Task<Response<CompanyDTO>> Handle(AddExistingEmployeeToCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.AddExistingEmployeeToCompany(request.companyId, request.employeeId);
         
            return Response.Success(company.Adapt<Company, CompanyDTO>(), "Added Existing Employee Successfully");

        }
    }
}
