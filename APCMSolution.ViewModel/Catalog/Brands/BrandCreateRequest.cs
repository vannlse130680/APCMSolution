using System;
using System.Collections.Generic;
using System.Text;

namespace APCMSolution.ViewModel.Catalog.Brands
{
    public class BrandCreateRequest
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
