using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class PopupStoreSession
    {
        public PopupStoreSession()
        {
            EmployeepPopupSessions = new HashSet<EmployeepPopupSession>();
            PopupActivities = new HashSet<PopupActivity>();
        }

        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int LocationId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string PictureCheckin { get; set; }
        public string PictureCheckout { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public int? Status { get; set; }

        public virtual PopUpStore PopUpStore { get; set; }
        public virtual ICollection<EmployeepPopupSession> EmployeepPopupSessions { get; set; }
        public virtual ICollection<PopupActivity> PopupActivities { get; set; }
    }
}
