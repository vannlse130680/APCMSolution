using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeGroupDetails = new HashSet<EmployeeGroupDetail>();
            EmployeepPopupSessions = new HashSet<EmployeepPopupSession>();
        }

        public int Id { get; set; }
        public int PromotionCompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? StartedDate { get; set; }

        public virtual PromotionCompany PromotionCompany { get; set; }
        public virtual ICollection<EmployeeGroupDetail> EmployeeGroupDetails { get; set; }
        public virtual ICollection<EmployeepPopupSession> EmployeepPopupSessions { get; set; }
    }
}
