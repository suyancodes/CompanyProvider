using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Enums;
using CompanyProvider.Domain.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CompanyProvider.API.Models
{
    public class NewCompanyViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string FantasyName { get; set; }

        [Display(Name = "Estado")]
        public UF Uf { get; set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }

        public NewCompanyViewModel()
        {
            States = Enum.GetValues(typeof(UF)).Cast<UF>().Select(e => new SelectListItem
            {
                Text = e.GetDescription(),
                Value = ((int)e).ToString()
            });
        }

        public NewCompanyViewModel(Company company) : this()
        {
            FantasyName = company.FantasyName;
            Uf = company.Uf;
            Cnpj = company.Cnpj;
        }
    }
}
