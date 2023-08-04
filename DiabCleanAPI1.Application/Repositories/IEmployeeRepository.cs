namespace DiabCleanAPI.DiabCleanAPI.Application.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public Task<Company?> GetEmployeeCompany(int id);
    }
}
