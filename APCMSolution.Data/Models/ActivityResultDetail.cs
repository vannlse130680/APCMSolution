using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class ActivityResultDetail
    {
        public int Id { get; set; }
        public int ActivityResultId { get; set; }
        public int? DirectObject { get; set; }
        public string DirectAttributeDetail { get; set; }

        public virtual ActivityResult ActivityResult { get; set; }
    }
}
