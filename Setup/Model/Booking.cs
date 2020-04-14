using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Setup.Models
{

    public class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }

        public ICollection<Account> Account { get; set; }
        public ICollection<Listing> Listing { get; set; }
    }
}

