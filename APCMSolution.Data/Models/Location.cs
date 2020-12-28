using System;
using System.Collections.Generic;

#nullable disable

namespace APCMSolution.Data.Models
{
    public partial class Location
    {
        public Location()
        {
            PopUpStores = new HashSet<PopUpStore>();
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PopUpStore> PopUpStores { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
