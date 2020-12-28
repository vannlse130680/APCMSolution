using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class ChainStore
    {
        public ChainStore()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
