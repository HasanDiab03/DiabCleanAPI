using DiabCleanAPI.Application.Commands.CompanyCommands;
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
        [HttpGet]
        public async Task<List<CompanyDTO>> Get([FromQuery] GetAllCompaniesQuery query)
            => await mediator.Send(query);
        [HttpGet("ById")]
        public async Task<CompanyDTO> Get([FromQuery] GetCompanyByIdQuery query)
            => await mediator.Send(query);
        [HttpPost]
        public async Task<CompanyDTO> Post(CreateCompanyCommand command)
            => await mediator.Send(command);
        [HttpPut]
        public async Task<CompanyDTO> Put(UpdateCompanyComand command)
            => await mediator.Send(command);
        [HttpDelete]
        public async Task Delete(DeleteCompanyCommand command)
            => await mediator.Send(command);
        [HttpPut("AddNewEmployee")]
        public async Task<CompanyDTO> Put(AddEmployeeToCompanyCommand command)
            => await mediator.Send(command);
        [HttpPut("AddExistingEmployee")]
        public async Task<CompanyDTO> Put(AddExistingEmployeeToCompanyCommand command)
            => await mediator.Send(command);
        [HttpDelete("RemoveEmployee")]
        public async Task<CompanyDTO> Put(RemoveEmployeeFromCompanyCommand command)
            => await mediator.Send(command);
    }
}
