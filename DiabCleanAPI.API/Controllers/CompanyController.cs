using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Queries.CompanyQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiabCleanAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        public readonly IMediator mediator;
        public CompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<List<CompanyDTO>> Get([FromQuery] GetAllCompaniesQuery query)
            => await mediator.Send(query);
        public async Task<CompanyDTO> Get([FromQuery] GetCompanyByIdQuery query)
            => await mediator.Send(query);
    }
}
