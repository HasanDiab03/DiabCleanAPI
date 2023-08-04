using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using MediatR;

namespace DiabCleanAPI.DiabCleanAPI.Application.Queries.CompanyQueries
{
    public record GetAllCompaniesQuery() : IRequest<List<CompanyDTO>>;
}
