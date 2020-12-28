using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class FormQuestionDetail
    {
        public int QuestionId { get; set; }
        public int FormId { get; set; }

        public virtual Form Form { get; set; }
    }
}
