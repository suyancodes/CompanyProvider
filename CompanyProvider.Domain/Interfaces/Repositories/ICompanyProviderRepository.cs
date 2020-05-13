using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Filters;
using System.Collections.Generic;

namespace CompanyProvider.Domain.Interfaces.Repositories
{
    public interface ICompanyProviderRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        IList<Entities.CompanyProvider> GetByFilter(CompanyProviderFilter companyProviderFilter);

        Domain.Entities.CompanyProvider GetByIdWithContacts(long id);
    }
}
