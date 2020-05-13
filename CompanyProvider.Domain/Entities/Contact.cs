using CompanyProvider.Domain.Dtos;

namespace CompanyProvider.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public Contact(long id)
        {
            Id = id;
        }

        public Contact(long companyProviderId, ContactDto dto)
        {
            Id = dto.Id;
            CompanyProviderId = companyProviderId;
            PhoneNumber = dto.PhoneNumber;
        }

        public string PhoneNumber { get; set; }
        public CompanyProvider CompanyProvider { get; set; }
        public long CompanyProviderId { get; set; }
    }
}
