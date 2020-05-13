using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Interfaces.Repositories;
using CompanyProvider.Infrastructure.Context;

namespace CompanyProvider.Infrastructure.Repositories
{
    public class ContactRepository<T> : BaseRepository<T>, IContactRepository<T> where T : Contact
    {
        private CompanyProviderContext _context;

        public ContactRepository(CompanyProviderContext context) : base(context)
        {
            _context = context;
        }

    }
}
