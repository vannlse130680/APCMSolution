using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class PopupActivity
    {
        public PopupActivity()
        {
            ActivityResults = new HashSet<ActivityResult>();
        }

        public int ActivityId { get; set; }
        public int PopupStoreSessionId { get; set; }
        public int? Status { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual PopupStoreSession PopupStoreSession { get; set; }
        public virtual ICollection<ActivityResult> ActivityResults { get; set; }
    }
}
