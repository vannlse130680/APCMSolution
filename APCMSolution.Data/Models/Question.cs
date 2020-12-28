using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string QuestionDetail { get; set; }
        public string Type { get; set; }
        public int? DirectObject { get; set; }
        public string DirectAttribute { get; set; }

        public virtual Form Form { get; set; }
    }
}
