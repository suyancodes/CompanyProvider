using CompanyProvider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyProvider.Domain.Dtos
{
    public class CompanyProviderDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public PersonType PersonType { get; set; }
        public string Rg { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime? BirthDate { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }

        public CompanyProviderDto()
        {
            Contacts = new List<ContactDto>();
        }

    }
}
