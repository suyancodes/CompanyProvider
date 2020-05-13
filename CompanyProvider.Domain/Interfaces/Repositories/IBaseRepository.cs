using CompanyProvider.Domain.Entities;
using System.Collections.Generic;

namespace CompanyProvider.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        BaseEntity Insert(T entity);

        void Update(T entity);

        T GetById(long id);

        IList<T> SelectAll();

        void Delete(T entity);
        void DeleteRange(IEnumerable<object> entities);
    }
}
