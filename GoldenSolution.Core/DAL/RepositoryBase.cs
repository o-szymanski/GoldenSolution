using Microsoft.EntityFrameworkCore;

namespace GoldenSolution.Core.DAL;

public class RepositoryBase<T> : IRepository<T> where T : class
{
	private readonly DbContext dbContext;
	protected DbSet<T> dbSet;

	public RepositoryBase(DbContext dbContext)
	{
		this.dbContext = dbContext;
		dbSet = this.dbContext.Set<T>();
	}

	public Task Add(T entity)
	{
		dbSet.Attach(entity);
		dbContext.SaveChanges();
		return Task.CompletedTask;
	}

	public Task Delete(T entity)
	{
		var result = dbSet.Find(entity);
		if (result != null)
		{
			dbSet.Remove(result);
			return Task.CompletedTask;
		}
		return Task.FromException(new Exception(""));
	}

	public Task<IEnumerable<T>> GetAll()
	{
		return Task.FromResult(dbSet.AsEnumerable());
	}

	public Task<T?> GetById(int id)
	{			
		return Task.FromResult(dbSet.Find(id));
	}

	public Task Update(T entity)
	{
		dbSet.Attach(entity);
		dbContext.Entry(entity).State = EntityState.Modified;
		dbContext.SaveChanges();
		return Task.CompletedTask;
	}
}
