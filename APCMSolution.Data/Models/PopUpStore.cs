using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class PopUpStore
    {
        public PopUpStore()
        {
            PopupStoreSessions = new HashSet<PopupStoreSession>();
        }

        public int CampaignId { get; set; }
        public int LocationId { get; set; }
        public string StoreId { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public string DecorativePhotoTemplate { get; set; }
        public int? Status { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<PopupStoreSession> PopupStoreSessions { get; set; }
    }
}
