using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
            StoreProductCategories = new HashSet<StoreProductCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<StoreProductCategory> StoreProductCategories { get; set; }
    }
}
