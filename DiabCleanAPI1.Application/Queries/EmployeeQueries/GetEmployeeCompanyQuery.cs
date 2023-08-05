using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Application.Queries.EmployeeQueries
{
    public record GetEmployeeCompanyQuery(int id) : IRequest<CompanyDTO>; 
}
