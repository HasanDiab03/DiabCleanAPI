using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using MediatR;
using Mapster;

namespace DiabCleanAPI.DiabCleanAPI.Application.Queries.CompanyQueries.Handlers
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyDTO>>
    {
        private readonly ICompanyRepository companyRepository;
        public GetAllCompaniesHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<List<CompanyDTO>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await companyRepository.GetAllAsync();
            var companiesDTO = companies.Adapt<List<Company>, List<CompanyDTO>>();
            return companiesDTO;
        }
    }
}
