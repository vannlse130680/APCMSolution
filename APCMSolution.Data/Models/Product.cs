using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductCampaigns = new HashSet<ProductCampaign>();
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public string Currency { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductCampaign> ProductCampaigns { get; set; }
    }
}
