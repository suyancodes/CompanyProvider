using CompanyProvider.API.Models;
using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Enums;
using CompanyProvider.Domain.Extensions;
using CompanyProvider.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyProvider.API.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            IList<Company> list = _service.GetCompanies().ToList();

            return View(new CompanyListViewModel { 
                Companies = list.Select(p => new CompanyViewModel(p)).ToList(),
                States = Enum.GetValues(typeof(UF)).Cast<UF>().Select(e => new SelectListItem
                {
                    Text = e.GetDescription(),
                    Value = ((int)e).ToString()
                })
            });
        }

        public IActionResult CreateCompany()
        {
            return LoadCompanyForm(new NewCompanyViewModel());
        }

        public IActionResult EditCompany(long id)
        {
            var model = new NewCompanyViewModel(_service.GetById(id));
            return LoadCompanyForm(model);
        }

        [HttpPost]
        public IActionResult SaveCompany(Company company)
        {
            _service.Save(company);

            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            _service.Delete(id);

            return Ok();
        }

        private IActionResult LoadCompanyForm(NewCompanyViewModel model)
        {
            return View("~/Views/Company/CompanyForm.cshtml", model);
        }
    }
}
