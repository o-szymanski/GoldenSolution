namespace GoldenSolution.Core.DAL;

public interface IRepository<T> where T : class
{
	Task<IQueryable<T>> GetQueryable();
	Task<List<T>> GetAll();
	Task<T?> GetById(int id);
	Task Insert(T entity);
	Task Update(T entity);
	Task Delete(T entity);
	Task SaveChanges();
}
