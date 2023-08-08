using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.Shared.RequestAbstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiabCleanAPI.Application.Commands.CompanyCommands
{
    public record RemoveEmployeeFromCompanyCommand(int companyId, int employeeId) : ICommand<CompanyDTO>;
}
