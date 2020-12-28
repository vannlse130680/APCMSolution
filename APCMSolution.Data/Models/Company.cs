using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class Company
    {
        public Company()
        {
            Brands = new HashSet<Brand>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Nation { get; set; }
        public string WebsiteUrl { get; set; }
        public string Email { get; set; }
        public string Hotline { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }
    }
}
