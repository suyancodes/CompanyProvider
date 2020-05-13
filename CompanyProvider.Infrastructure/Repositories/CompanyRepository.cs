using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Interfaces.Repositories;
using CompanyProvider.Infrastructure.Context;

namespace CompanyProvider.Infrastructure.Repositories
{
    public class CompanyRepository<T> : BaseRepository<T>, ICompanyRepository<T> where T : Company
    {
        private CompanyProviderContext _context;

        public CompanyRepository(CompanyProviderContext context) : base(context)
        {
            _context = context;
        }

    }
}
