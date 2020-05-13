using CompanyProvider.Domain.Entities;

namespace CompanyProvider.Domain.Interfaces.Repositories
{
    public interface IContactRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
    }
}
