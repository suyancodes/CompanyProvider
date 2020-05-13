using CompanyProvider.Domain.Entities;
using System.Collections.Generic;

namespace CompanyProvider.Domain.Interfaces.Services
{
    public interface ICompanyService
    {
        IList<Company> GetCompanies();
        void Save(Company entity);
        void Delete(long id);
        Company GetById(long id);
    }
}
