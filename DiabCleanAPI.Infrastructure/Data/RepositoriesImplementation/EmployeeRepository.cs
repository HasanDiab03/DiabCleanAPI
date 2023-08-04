using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using DiabCleanAPI.DiabCleanAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace DiabCleanAPI.DiabCleanAPI.Infrastructure.Data.RepositoriesImplementation
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDBContext context;
        private readonly DbSet<Employee> employees;
        public EmployeeRepository(AppDBContext context) : base(context) 
        { 
            this.context = context;
            this.employees = this.context.Set<Employee>();
        }
        public async Task<Company?> GetEmployeeCompany(int id)
        {
            var employee = await employees.Include(e => e.Company).FirstOrDefaultAsync(e => e.Id == id)
                            ?? throw new NotFoundException(id);
            return employee.Company;
        }
    }
}
