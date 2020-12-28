using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class Form
    {
        public Form()
        {
            Activities = new HashSet<Activity>();
            FormQuestionDetails = new HashSet<FormQuestionDetail>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<FormQuestionDetail> FormQuestionDetails { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
