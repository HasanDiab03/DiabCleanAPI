using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using DiabCleanAPI.DiabCleanAPI.Shared;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DiabCleanAPI.DiabCleanAPI.Infrastructure.Data.RepositoriesImplementation
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly AppDBContext context;
        private readonly DbSet<Company> companies;
        private readonly IValidator<Employee> validator;
        public CompanyRepository(AppDBContext context, IValidator<Employee> validator) : base(context) 
        {
            this.validator = validator;
            this.context = context;
            this.companies = this.context.Set<Company>();
        }
        public async Task<Company> AddEmployeeToCompanyAsync(int companyId, string name, string address, string phone, string email)
        {
            var company = await companies.FirstOrDefaultAsync(c => c.Id == companyId)
                ?? throw new NotFoundException(companyId);

            var employee = new Employee(name, address, phone, email);
            company.Employees.Add(employee);
            context.Update(company);
            await context.SaveChangesAsync();
            return company;
        }
        public async Task<Company> AddExistingEmployeeToCompany(int companyId, int employeeId)
        {
            var employee = await context.Employee.FirstOrDefaultAsync(e => e.Id == employeeId)
                ?? throw new NotFoundException(employeeId);
            var company = await companies.FirstOrDefaultAsync(c => c.Id == companyId)
                ?? throw new NotFoundException(companyId);
            company.Employees.Add(employee);
            context.Update(company);
            await context.SaveChangesAsync();
            return company;
        }
        public async Task<Company> RemoveEmployeeFromCompanyAsync(int companyId, int employeeId)
        {
            var company = await companies.Include(c => c.Employees).FirstOrDefaultAsync(c => c.Id == companyId)
                ?? throw new NotFoundException(companyId);

            var employee = company.Employees.FirstOrDefault(e => e.Id == employeeId)
                ?? throw new NotFoundException(employeeId);

            company.Employees.Remove(employee);
            context.Update(company);
            await context.SaveChangesAsync();
            return company;
        }
    }
}
