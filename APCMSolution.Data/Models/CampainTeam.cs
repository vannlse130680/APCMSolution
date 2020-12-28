using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class CampainTeam
    {
        public string CtId { get; set; }
        public int CampainId { get; set; }
        public string EmpGroupId { get; set; }
        public DateTime? StartedDate { get; set; }
        public int? Status { get; set; }
    }
}
