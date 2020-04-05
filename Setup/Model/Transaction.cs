using System;
using System.Collections.Generic;

namespace Setup.Models
{

    public class Transaction
    {
        public int TransactionID { get; set; }
        public int Price { get; set; }
        public DateTime TransactionDate { get; set; }

        public ICollection<Booking> Booking { get; set; }

    }
}
