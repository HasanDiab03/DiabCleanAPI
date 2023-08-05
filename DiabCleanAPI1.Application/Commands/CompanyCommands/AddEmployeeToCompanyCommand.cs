using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Application.Commands.CompanyCommands
{
    public record AddEmployeeToCompanyCommand(int id, string name, string address, string phone, string email) : IRequest<CompanyDTO>;
}
