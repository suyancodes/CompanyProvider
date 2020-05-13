using CompanyProvider.Domain.Enums;
using System;

namespace CompanyProvider.Domain.Filters
{
    public class CompanyProviderFilter
    {
        public string Name { get; set; }
        public PersonType PersonType { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
