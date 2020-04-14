using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Setup.Models
{

    public class Time
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeID { get; set; }
        public DateTime Timeset { get; set; }
        public string Description { get; set; }

    }
}
