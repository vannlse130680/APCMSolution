using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class Activity
    {
        public Activity()
        {
            PopupActivities = new HashSet<PopupActivity>();
        }

        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int? ActivityLevel { get; set; }
        public int? FormId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? Status { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Form Form { get; set; }
        public virtual ICollection<PopupActivity> PopupActivities { get; set; }
    }
}
