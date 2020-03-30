using System;
using System.Collections.Generic;

namespace Setup.Models
{

    public class Booking
    {
        public int BookID { get; set; }

        public ICollection<Account> Accounts { get; set; }
        public ICollection<Listing> Lists { get; set; }
    }
}
