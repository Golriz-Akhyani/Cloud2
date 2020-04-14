using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Setup.Models
{

    public class Listing
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ListingID { get; set; }
        public DateTime ListingDate { get; set; }
        public int Capacity { get; set; }



        public ICollection<Place> Place { get; set; }
        public ICollection<Time> Time { get; set; }
    }
}
