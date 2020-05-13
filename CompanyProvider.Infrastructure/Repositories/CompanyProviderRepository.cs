using CompanyProvider.Domain.Filters;
using CompanyProvider.Domain.Interfaces.Repositories;
using CompanyProvider.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CompanyProvider.Infrastructure.Repositories
{
    public class CompanyProviderRepository<T> : BaseRepository<T>, ICompanyProviderRepository<T> where T : Domain.Entities.CompanyProvider
    {
        private CompanyProviderContext _context;

        public CompanyProviderRepository(CompanyProviderContext context) : base(context)
        {
            _context = context;
        }

        public IList<Domain.Entities.CompanyProvider> GetByFilter(CompanyProviderFilter companyProviderFilter)
        {
            IQueryable<Domain.Entities.CompanyProvider> query = _context.CompanyProviders.Include(p => p.Company).Include(p => p.Contacts);

            if (!string.IsNullOrEmpty(companyProviderFilter.Name))
            {
                var nameLowerCase = companyProviderFilter.Name.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(nameLowerCase));
            }

            if (!string.IsNullOrEmpty(companyProviderFilter.CpfCnpj))
            {
                query = query.Where(p => !string.IsNullOrEmpty(p.CpfCnpj) && p.CpfCnpj.Contains(companyProviderFilter.CpfCnpj));
            }

            if (companyProviderFilter.CreatedDate.HasValue)
            {
                query = query.Where(p => p.CreatedDate.Date == companyProviderFilter.CreatedDate.Value.Date);
            }

            return query.ToList();
        }

        public Domain.Entities.CompanyProvider GetByIdWithContacts(long id)
        {
            return _context.CompanyProviders.Include(p => p.Contacts).FirstOrDefault(p => p.Id == id);
        }
    }
}
