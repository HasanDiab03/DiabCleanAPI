using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using DiabCleanAPI.DiabCleanAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace DiabCleanAPI.DiabCleanAPI.Infrastructure.Data.RepositoriesImplementation
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDBContext context;
        private readonly DbSet<TEntity> dbSet;
        public BaseRepository(AppDBContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }
        public async Task<List<TEntity>> GetAllAsync()
            => await dbSet.ToListAsync();
        
        public async Task<TEntity> GetByIdAsync(int id)
            => await dbSet.FindAsync(id) ?? throw new NotFoundException(id);
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var created = await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return created.Entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updated = dbSet.Update(entity);
            await context.SaveChangesAsync();
            return updated.Entity;
        }
        public async Task DeleteAsync(int id)
        {
            var delete = await GetByIdAsync(id);
            dbSet.Remove(delete);
            await context.SaveChangesAsync();

        }
    }
}
