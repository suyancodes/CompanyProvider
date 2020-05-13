using System.Collections.Generic;

namespace CompanyProvider.API.Models
{
    public class CompanyProviderListViewModel
    {
        public int TotalCount { get; set; }
        public List<CompanyProviderViewModel> Providers { get; set; }
    }
}
