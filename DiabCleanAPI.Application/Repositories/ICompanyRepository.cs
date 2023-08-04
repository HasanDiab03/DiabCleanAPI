
namespace DiabCleanAPI.DiabCleanAPI.Application.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        public Task<Company> AddEmployeeToCompanyAsync(int companyId, string name, string address, string phone, string email);
        public Task<Company> AddExistingEmployeeToCompany(int companyId, int employeeId);
        public Task<Company> RemoveEmployeeFromCompanyAsync(int companyId, int employeeId);
    }
}
