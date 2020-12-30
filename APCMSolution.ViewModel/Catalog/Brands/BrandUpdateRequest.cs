using System;
using System.Collections.Generic;
using System.Text;

namespace APCMSolution.ViewModel.Catalog.Brands
{
    public class BrandUpdateRequest
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
