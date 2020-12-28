using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class BrandStoreGroup
    {
        public int BrandId { get; set; }
        public int StoreId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Store Store { get; set; }
    }
}
