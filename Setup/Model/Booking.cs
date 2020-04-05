using System;
using System.Collections.Generic;

namespace Setup.Models
{

    public class Booking
    {
        public int BookingID { get; set; }

        public ICollection<Account> Account { get; set; }
        public ICollection<Listing> Listing { get; set; }
    }
}
