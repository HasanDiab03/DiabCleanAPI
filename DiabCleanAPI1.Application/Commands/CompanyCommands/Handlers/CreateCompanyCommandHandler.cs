using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using FluentValidation;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Application.Commands.CompanyCommands.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyDTO>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IValidator<Company> validator;
        public CreateCompanyCommandHandler(IValidator<Company> validator, ICompanyRepository companyRepository)
        {
            this.validator = validator;
            this.companyRepository = companyRepository;
        }
        public async Task<CompanyDTO> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var (Name, Field) = request;
            var add = new Company(Name, Field);
            var validate = await validator.ValidateAsync(add);
            if(!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            var company = await companyRepository.AddAsync(add);
            return company.Adapt<Company, CompanyDTO>();
        }
    }
}
