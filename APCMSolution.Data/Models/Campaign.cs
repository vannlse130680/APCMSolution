using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            Activities = new HashSet<Activity>();
            PopUpStores = new HashSet<PopUpStore>();
            ProductCampaigns = new HashSet<ProductCampaign>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal? BudgetedCost { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public decimal? ExpectedRevenue { get; set; }
        public decimal? ActualRevenue { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<PopUpStore> PopUpStores { get; set; }
        public virtual ICollection<ProductCampaign> ProductCampaigns { get; set; }
    }
}
