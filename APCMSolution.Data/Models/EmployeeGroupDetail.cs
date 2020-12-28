using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class EmployeeGroupDetail
    {
        public int EmployeeGroupId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int? Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual EmployeeGroup EmployeeGroup { get; set; }
    }
}
