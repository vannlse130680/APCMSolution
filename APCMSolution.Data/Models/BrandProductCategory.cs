using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class BrandProductCategory
    {
        public int BrandProductCategoryId { get; set; }
        public string BrandId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
