using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Extensions;

namespace CompanyProvider.API.Models
{
    public class CompanyViewModel
    {
        public long Id { get; set; }
        public string FantasyName { get; set; }
        public string Uf { get; set; }
        public string Cnpj { get; set; }

        public CompanyViewModel(Company company)
        {
            Id = company.Id;
            FantasyName = company.FantasyName;
            Uf = company.Uf.GetDescription();
            Cnpj = company.Cnpj;
        }
    }
}
