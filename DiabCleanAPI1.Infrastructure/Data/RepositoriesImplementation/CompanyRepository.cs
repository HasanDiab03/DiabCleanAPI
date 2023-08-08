using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using DiabCleanAPI.DiabCleanAPI.Shared;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DiabCleanAPI.DiabCleanAPI.Infrastructure.Data.RepositoriesImplementation
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly AppDBContext _context;
        private readonly DbSet<Company> _companies;
        public CompanyRepository(AppDBContext context) : base(context) 
        {
            _context = context;
            _companies = _context.Set<Company>();
        }
        public new async Task<List<Company>> GetAllAsync()
            => await _companies.Include(c => c.Employees).ToListAsync();
        public async Task<Company> AddEmployeeToCompanyAsync(int companyId, string name, string address, string phone, string email)
        {
            var company = await _companies.FirstOrDefaultAsync(c => c.Id == companyId)
                ?? throw new NotFoundException(companyId);

            var employee = new Employee(name, address, phone, email);
            company.Employees.Add(employee);
            _context.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }
        public async Task<Company> AddExistingEmployeeToCompany(int companyId, int employeeId)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(e => e.Id == employeeId)
                ?? throw new NotFoundException(employeeId);
            var company = await _companies.FirstOrDefaultAsync(c => c.Id == companyId)
                ?? throw new NotFoundException(companyId);
            company.Employees.Add(employee);
            _context.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }
        public async Task<Company> RemoveEmployeeFromCompanyAsync(int companyId, int employeeId)
        {
            var company = await _companies.Include(c => c.Employees).FirstOrDefaultAsync(c => c.Id == companyId)
                ?? throw new NotFoundException(companyId);

            var employee = company.Employees.FirstOrDefault(e => e.Id == employeeId)
                ?? throw new NotFoundException(employeeId);

            company.Employees.Remove(employee);
            _context.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }
    }
}
