using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Scheduler.Data.Interfaces;

namespace Scheduler.Data.Repositories;

public class GenericRepository<T>(SchedulerDbContext context) : IGenericRepository<T>
	where T : class
{
	protected readonly SchedulerDbContext Context = context;
	private readonly DbSet<T> _dbSet = context.Set<T>();

	public async Task<T?> GetByIdAsync(int id) =>
		await _dbSet.FindAsync(id);

	public async Task<IEnumerable<T>> GetAllAsync() =>
		await _dbSet.ToListAsync();

	public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
		await _dbSet.Where(predicate).ToListAsync();

	public async Task AddAsync(T entity) =>
		await _dbSet.AddAsync(entity);

	public void Remove(T entity) =>
		_dbSet.Remove(entity);

	public async Task<int> SaveChangesAsync() =>
		await Context.SaveChangesAsync();
}