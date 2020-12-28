using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class EmployeepPopupSession
    {
        public int PopupStoreSessionId { get; set; }
        public int EmployeeId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Status { get; set; }
        public int? Role { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual PopupStoreSession PopupStoreSession { get; set; }
    }
}
