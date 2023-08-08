using DiabCleanAPI.Application.Commands.EmployeeCommands;
using DiabCleanAPI.Application.Commands.EmployeeCommands.Handlers;
using DiabCleanAPI.Application.Queries.EmployeeQueries;
using DiabCleanAPI.DiabCleanAPI.Application.Commands.EmployeeCommands;
using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Queries.EmployeeQueries;
using DiabCleanAPI.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiabCleanAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public readonly IMediator mediator;
        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<List<EmployeeDTO>> Get([FromQuery] GetAllEmployeesQuery query)
            => await mediator.Send(query);
        [HttpGet("ById")]
        public async Task<EmployeeDTO> Get([FromQuery] GetEmployeeByIdQuery query)
            => await mediator.Send(query);
        [HttpPost]
        public async Task<Response<EmployeeDTO>> Post(CreateEmployeeCommand command)
            => await mediator.Send(command);
        [HttpPut]
        public async Task<Response<EmployeeDTO>> Put(UpdateEmployeeCommand command)
            => await mediator.Send(command);
        [HttpDelete]
        public async Task Delete(DeleteEmployeeCommand command)
            => await mediator.Send(command);
        [HttpGet("GetCompany")]
        public async Task<CompanyDTO?> Get([FromQuery] GetEmployeeCompanyQuery query)
            => await mediator.Send(query);
    }
}
