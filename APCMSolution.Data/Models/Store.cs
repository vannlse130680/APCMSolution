using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class Store
    {
        public Store()
        {
            BrandStoreGroups = new HashSet<BrandStoreGroup>();
            StoreProductCategories = new HashSet<StoreProductCategory>();
        }

        public int Id { get; set; }
        public int? ChainStoreId { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Hotline { get; set; }

        public virtual ChainStore ChainStore { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<BrandStoreGroup> BrandStoreGroups { get; set; }
        public virtual ICollection<StoreProductCategory> StoreProductCategories { get; set; }
    }
}
