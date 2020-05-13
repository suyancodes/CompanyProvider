using CompanyProvider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyProvider.Infrastructure.Mapping
{
	public class ContactMap : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.PhoneNumber).IsRequired();
			
			builder.HasOne(c => c.CompanyProvider).WithMany(p => p.Contacts).HasForeignKey(p => p.CompanyProviderId).IsRequired();
		}
	}
}
