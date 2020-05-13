using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CompanyProvider.Domain.Entities;

namespace CompanyProvider.Infrastructure.Mapping
{
	public class CompanyMap : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.FantasyName).IsRequired();
			builder.Property(c => c.Uf).IsRequired();
			builder.Property(c => c.Cnpj).IsRequired();
		}
	}
}
