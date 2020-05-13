using CompanyProvider.Domain.Entities;

namespace CompanyProvider.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
    }
}
