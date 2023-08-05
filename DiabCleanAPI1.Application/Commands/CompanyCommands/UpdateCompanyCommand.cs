﻿using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Application.Commands.CompanyCommands
{
    public record UpdateCompanyComand(int id, string name, string field) : IRequest<CompanyDTO>;
}