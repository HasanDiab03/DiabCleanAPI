using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using Mapster;
using MediatR;

namespace DiabCleanAPI.DiabCleanAPI.Application.Queries.CompanyQueries.Handlers
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDTO>
    {
        private readonly ICompanyRepository companyRepository;
        public GetCompanyByIdHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public async Task<CompanyDTO> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await companyRepository.GetByIdAsync(request.Id);
            return company.Adapt<Company, CompanyDTO>();
        }
    }
}
