using CompanyProvider.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CompanyProvider.API.Models
{
    public class NewCompanyProviderViewModel
    {
        public long Id { get; set; }

        public IEnumerable<SelectListItem> Companies { get; set; }
        
        [Display(Name = "Empresa")]
        public long CompanyId { get; set; }
        
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Tipo de Pessoa")]
        public PersonType PersonType { get; set; }

        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Contatos")]
        public IEnumerable<ContactViewModel> Contacts { get; set; }

        public NewCompanyProviderViewModel()
        {
            Contacts = new List<ContactViewModel>();
        }

        public NewCompanyProviderViewModel(Domain.Entities.CompanyProvider entity)
        {
            Id = entity.Id;
            CompanyId = entity.CompanyId;
            Name = entity.Name;
            PersonType = entity.PersonType;
            CpfCnpj = entity.CpfCnpj;
            Rg = entity.Rg;
            BirthDate = entity.BirthDate;
            Contacts = entity.Contacts.Select(p => new ContactViewModel()
            {
                Id = p.Id,
                PhoneNumber = p.PhoneNumber
            });
        }

    }
}
