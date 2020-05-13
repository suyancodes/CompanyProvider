using CompanyProvider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyProvider.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string FantasyName { get; set; }
        public UF Uf { get; set; }
        public string Cnpj { get; set; }
        public List<CompanyProvider> Providers { get; set; }
    }
}
