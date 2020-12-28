using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class ActivityResult
    {
        public ActivityResult()
        {
            ActivityResultDetails = new HashSet<ActivityResultDetail>();
        }

        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int PopupStoreSessionId { get; set; }
        public string AnswerOfQuestion { get; set; }

        public virtual PopupActivity PopupActivity { get; set; }
        public virtual ICollection<ActivityResultDetail> ActivityResultDetails { get; set; }
    }
}
