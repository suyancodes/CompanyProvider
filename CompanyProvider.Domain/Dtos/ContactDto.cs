namespace CompanyProvider.Domain.Dtos
{
    public class ContactDto
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool ToDelete { get; set; }

    }
}
