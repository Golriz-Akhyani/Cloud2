using System;
using System.Collections.Generic;

namespace Setup.Models
{

    public class Listing
    {
        public int ListingID { get; set; }
        public DateTime ListingDate { get; set; }
        public int Capacity { get; set; }



        public ICollection<Place> Places { get; set; }
        public ICollection<Time>Time { get; set; }
    }
}
