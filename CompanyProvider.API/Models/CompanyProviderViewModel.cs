using CompanyProvider.Domain.Enums;
using CompanyProvider.Domain.Extensions;
using System.Linq;

namespace CompanyProvider.API.Models
{
    public class CompanyProviderViewModel
    {
        public long Id { get; set; }
        public string CompanyFantasyName { get; set; }
        public string Uf { get; set; }
        public string Name { get; set; }
        public string Rg { get; set; }
        public string CpfCnpj { get; set; }
        public string BirthDate { get; set; }
        public string Contacts { get; set; }

        public CompanyProviderViewModel()
        { }

        public CompanyProviderViewModel(Domain.Entities.CompanyProvider companyProvider)
        {
            Id = companyProvider.Id;
            CompanyFantasyName = companyProvider.Company.FantasyName;
            Uf = companyProvider.Company.Uf.GetDescription();
            Name = companyProvider.Name;
            CpfCnpj = companyProvider.CpfCnpj;
            Rg = companyProvider.Rg ?? "-";
            BirthDate = companyProvider.BirthDate.HasValue ? companyProvider.BirthDate.Value.ToString("dd/MM/yyyy") : "-";
            Contacts = string.Join(", ", companyProvider.Contacts.Select(p => p.PhoneNumber));
        }
    }
}
