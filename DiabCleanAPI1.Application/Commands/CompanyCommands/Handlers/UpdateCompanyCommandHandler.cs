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
    public class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyComand, CompanyDTO>
    {
        private readonly ICompanyRepository companyRepository;
        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public async Task<Response<CompanyDTO>> Handle(UpdateCompanyComand request, CancellationToken cancellationToken)
        {
            var (id, name, field) = request;
            var toUpdate = await companyRepository.GetByIdAsync(id);
            toUpdate.Update(name, field);
            var updated = await companyRepository.UpdateAsync(toUpdate);
            return Response.Success(updated.Adapt<Company, CompanyDTO>(), "Succesfully updated company details");
        }
    }
}
