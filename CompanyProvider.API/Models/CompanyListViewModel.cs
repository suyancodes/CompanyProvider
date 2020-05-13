using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CompanyProvider.API.Models
{
    public class CompanyListViewModel
    {
        public int TotalCount { get; set; }
        public List<CompanyViewModel> Companies { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
    }
}
