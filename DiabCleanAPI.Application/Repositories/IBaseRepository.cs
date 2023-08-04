namespace DiabCleanAPI.DiabCleanAPI.Application.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class 
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
