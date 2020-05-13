using Microsoft.EntityFrameworkCore;
using CompanyProvider.Domain.Entities;
using CompanyProvider.Infrastructure.Extensions;
using CompanyProvider.Infrastructure.Mapping;

namespace CompanyProvider.Infrastructure.Context
{
    public class CompanyProviderContext : DbContext
    {
        public CompanyProviderContext()
        {

        }

        public CompanyProviderContext(DbContextOptions<CompanyProviderContext> options)
          : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.Entity<Company>(new CompanyMap().Configure);
            modelBuilder.Entity<Domain.Entities.CompanyProvider>(new CompanyProviderMap().Configure);
            modelBuilder.Entity<Contact>(new ContactMap().Configure);
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Domain.Entities.CompanyProvider> CompanyProviders { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual void SetModified(BaseEntity entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
