using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class Brand
    {
        public Brand()
        {
            BrandStoreGroups = new HashSet<BrandStoreGroup>();
            Forms = new HashSet<Form>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<BrandStoreGroup> BrandStoreGroups { get; set; }
        public virtual ICollection<Form> Forms { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
