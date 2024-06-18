using Microsoft.EntityFrameworkCore;

namespace GoldenSolution.Core.DAL;

public class RepositoryBase<T> : IRepository<T> where T : class
{
	private readonly DbContext _context;

	public RepositoryBase(DbContext dbContext)
	{
		_context = dbContext;
	}

	public Task<IQueryable<T>> GetQueryable()
	{
		return Task.FromResult(_context.Set<T>().AsQueryable());
	}

	public async Task<List<T>> GetAll()
  {
	  return await _context.Set<T>().ToListAsync();
  }

  public async Task<T?> GetById(int id)
  {
	  return await _context.Set<T>().FindAsync(id);
  }

  public async Task Insert(T entity)
  {
	  await _context.Set<T>().AddAsync(entity);
  }

	public Task Update(T entity)
	{
		_context.Set<T>().Update(entity);
		return Task.CompletedTask;
	}

	public Task Delete(T entity)
	{
		_context.Set<T>().Remove(entity);
		return Task.CompletedTask;
	}

	public async Task SaveChanges()
	{
		await _context.SaveChangesAsync();
	}
}
