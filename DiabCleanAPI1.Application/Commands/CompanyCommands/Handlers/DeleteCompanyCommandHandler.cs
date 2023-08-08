using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using DiabCleanAPI.Shared;
using DiabCleanAPI.Shared.RequestAbstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Application.Commands.CompanyCommands.Handlers
{
    public class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand, Unit>
    {
        private readonly ICompanyRepository companyRepository;
        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public async Task<Response<Unit>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            await companyRepository.DeleteAsync(request.id);
            return Response.Success(Unit.Value, "Successfully deleted company");

        }
    }
}
