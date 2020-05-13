using CompanyProvider.API.Models;
using CompanyProvider.Domain.Dtos;
using CompanyProvider.Domain.Filters;
using CompanyProvider.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CompanyProvider.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyProviderService _providerService;
        private readonly ICompanyService _companyService;

        public HomeController(ICompanyProviderService providerService, ICompanyService companyService)
        {
            _providerService = providerService;
            _companyService = companyService;
        }

        public IActionResult Index(CompanyProviderFilter filter)
        {
            IList<Domain.Entities.CompanyProvider> list = _providerService.GetProvidersByFilter(filter).ToList();

            return View(new CompanyProviderListViewModel { Providers = list.Select(p => new CompanyProviderViewModel(p)).ToList() });
        }

        public IActionResult CreateProvider()
        {
            return LoadProviderForm(new NewCompanyProviderViewModel());
        }

        public IActionResult EditProvider(long id)
        {
            var model = new NewCompanyProviderViewModel(_providerService.GetByIdWithContacts(id));
            return LoadProviderForm(model);
        }

        [HttpPost]
        public IActionResult SaveProvider(CompanyProviderDto provider)
        {
            _providerService.Save(provider);

            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            _providerService.Delete(id);

            return Ok();
        }

        private IActionResult LoadProviderForm(NewCompanyProviderViewModel model)
        {
            var companies = _companyService.GetCompanies().Select(p => new SelectListItem() { Text = p.FantasyName, Value = p.Id.ToString() });
            model.Companies = companies;

            return View("~/Views/Home/ProviderForm.cshtml", model);
        }
    }
}
