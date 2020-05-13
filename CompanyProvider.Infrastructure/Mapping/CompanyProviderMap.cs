using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyProvider.Infrastructure.Mapping
{
	public class CompanyProviderMap : IEntityTypeConfiguration<CompanyProvider.Domain.Entities.CompanyProvider>
	{
		public void Configure(EntityTypeBuilder<CompanyProvider.Domain.Entities.CompanyProvider> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Name).IsRequired();
			builder.Property(c => c.PersonType).IsRequired();
			builder.Property(c => c.Rg);
			builder.Property(c => c.CpfCnpj).IsRequired();
			builder.Property(c => c.BirthDate);
			builder.Property(c => c.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
			
			builder.HasOne(c => c.Company).WithMany(p => p.Providers).HasForeignKey(p => p.CompanyId).IsRequired();
		}
	}
}
