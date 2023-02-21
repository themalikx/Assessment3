using Assesment3.Db;
using Microsoft.EntityFrameworkCore;

namespace Assesment3.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task<int> CompleteAsync()
    {
        return _dbContext.SaveChangesAsync();
    }

    public IQueryable<T> Table => _dbSet;
    public AppDbContext Context => _dbContext;

    public async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    public T Get(Func<T, Boolean> where) => Enumerable.Where(_dbSet, where).FirstOrDefault<T>();
}