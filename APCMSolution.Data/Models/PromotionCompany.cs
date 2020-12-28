using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class PromotionCompany
    {
        public PromotionCompany()
        {
            EmployeeGroups = new HashSet<EmployeeGroup>();
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<EmployeeGroup> EmployeeGroups { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
