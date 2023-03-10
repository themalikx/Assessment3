using Assesment3.Db;
using Microsoft.EntityFrameworkCore;

namespace Assesment3.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<int> CountAsync();
    Task<int> CompleteAsync();
    IQueryable<T> Table { get; }
    public AppDbContext Context { get; }
    T Get(Func<T, bool> where);
}