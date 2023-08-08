using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.Shared.RequestAbstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Application.Commands.CompanyCommands
{
    public record AddExistingEmployeeToCompanyCommand(int companyId, int employeeId) : ICommand<CompanyDTO>;
}
