using DiabCleanAPI.Application.Commands.EmployeeCommands;
using DiabCleanAPI.Application.Commands.EmployeeCommands.Handlers;
using DiabCleanAPI.DiabCleanAPI.Application.Commands.EmployeeCommands;
using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Queries.EmployeeQueries;
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
        public async Task<List<EmployeeDTO>> Get([FromQuery] GetAllEmployeesQuery query)
            => await mediator.Send(query);
        public async Task<EmployeeDTO> Get([FromQuery] GetEmployeeByIdQuery query)
            => await mediator.Send(query);
        public async Task<EmployeeDTO> Post(CreateEmployeeCommand command)
            => await mediator.Send(command);
        public async Task<EmployeeDTO> Put(UpdateEmployeeCommand command)
            => await mediator.Send(command);
        public async Task Delete(DeleteEmployeeCommand command)
            => await mediator.Send(command);
    }
}
