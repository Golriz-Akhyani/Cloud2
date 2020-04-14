using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Setup.Models
{

    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }
        public int Price { get; set; }
        public DateTime TransactionDate { get; set; }

        public ICollection<Booking> Booking { get; set; }

    }
}
