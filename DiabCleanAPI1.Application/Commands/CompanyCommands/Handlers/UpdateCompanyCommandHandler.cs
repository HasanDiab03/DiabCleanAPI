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
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyComand, CompanyDTO>
    {
        private readonly ICompanyRepository companyRepository;
        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public async Task<CompanyDTO> Handle(UpdateCompanyComand request, CancellationToken cancellationToken)
        {
            var (id, name, field) = request;
            var toUpdate = await companyRepository.GetByIdAsync(id);
            toUpdate.Update(name, field);
            var updated = await companyRepository.UpdateAsync(toUpdate);
            return updated.Adapt<Company, CompanyDTO>();
        }
    }
}
