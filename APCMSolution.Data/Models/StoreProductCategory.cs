using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class StoreProductCategory
    {
        public int ProductCategoryId { get; set; }
        public int StoreId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Store Store { get; set; }
    }
}
