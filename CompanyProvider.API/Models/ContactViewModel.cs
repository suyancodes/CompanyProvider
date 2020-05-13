namespace CompanyProvider.API.Models
{
    public class ContactViewModel
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool ToDelete { get; set; }
    }
}
