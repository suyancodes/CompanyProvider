using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Interfaces.Repositories;
using CompanyProvider.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace CompanyProvider.Infrastructure.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		private CompanyProviderContext _context;

		public BaseRepository(CompanyProviderContext context)
		{
			_context = context;
		}

		public BaseEntity Insert(T entity)
		{
			_context.Set<T>().Add(entity);
			_context.SaveChanges();
			return entity;
		}

		public T GetById(long id)
		{
			return _context.Set<T>().FirstOrDefault(p => p.Id == id);
		}

		public IList<T> SelectAll()
		{
			return _context.Set<T>().ToList();
		}

		public void Update(T entity)
		{
			_context.SetModified(entity);
			_context.SaveChanges();
		}

		public void Delete(T entity)
		{
			_context.Remove(entity);
			_context.SaveChanges();
		}
		public void DeleteRange(IEnumerable<object> entities)
		{
			_context.RemoveRange(entities);
			_context.SaveChanges();
		}
	}
}
