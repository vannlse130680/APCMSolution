using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class EmployeeGroup
    {
        public EmployeeGroup()
        {
            EmployeeGroupDetails = new HashSet<EmployeeGroupDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Status { get; set; }
        public int? PromotionCompanyId { get; set; }

        public virtual PromotionCompany PromotionCompany { get; set; }
        public virtual ICollection<EmployeeGroupDetail> EmployeeGroupDetails { get; set; }
    }
}
