using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class ProductCampaign
    {
        public int CampaignId { get; set; }
        public int ProductId { get; set; }
        public int? Status { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Product Product { get; set; }
    }
}
