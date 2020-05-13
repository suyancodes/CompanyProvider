using CompanyProvider.Domain.Dtos;
using CompanyProvider.Domain.Filters;
using System.Collections.Generic;

namespace CompanyProvider.Domain.Interfaces.Services
{
    public interface ICompanyProviderService
    {
        IList<Entities.CompanyProvider> GetProvidersByFilter(CompanyProviderFilter companyProviderFilter);
        IList<Entities.CompanyProvider> GetProviders();
        void Save(CompanyProviderDto dto);
        void Delete(long id);
        Entities.CompanyProvider GetByIdWithContacts(long id);
    }
}
