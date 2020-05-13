using CompanyProvider.Domain.Dtos;
using CompanyProvider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyProvider.Domain.Entities
{
    public class CompanyProvider : BaseEntity
    {
        public CompanyProvider()
        {

        }

        public CompanyProvider(CompanyProviderDto dto)
        {
            Id = dto.Id;
            CompanyId = dto.CompanyId;
            Name = dto.Name;
            PersonType = dto.PersonType;
            Rg = dto.Rg;
            CpfCnpj = dto.CpfCnpj;
            BirthDate = dto.BirthDate;
            Contacts = dto.Contacts.Where(p => !p.ToDelete).Select(contact => new Contact(dto.Id, contact)).ToList();
        }

        public Company Company { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public PersonType PersonType { get; set; }
        public string Rg { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
