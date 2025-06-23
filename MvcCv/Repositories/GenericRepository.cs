using MvcCv.DAL.Context;
using System.Linq.Expressions;

namespace MvcCv.Repositories
{
	public class GenericRepository<T> where T:class,new()
	{
		private readonly MvcCvContext _context;

		public List<T> List()
		{
			return _context.Set<T>().ToList();
		}

		public void TAdd(T p)
		{
			_context.Set<T>().Add(p);
			_context.SaveChanges();
		}

		public void TDelete(T p)
		{
			_context.Set<T>().Remove(p);
			_context.SaveChanges();
		}

		public T TGet(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public void TUpdate(T p)
		{
			_context.SaveChanges();
		}

		public T Find(Expression<Func<T, bool>> where)
		{
			return _context.Set<T>().FirstOrDefault(where);
		}

	}
}
