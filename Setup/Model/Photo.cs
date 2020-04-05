using System;
using System.Collections.Generic;

namespace Setup.Models
{

    public class Photo
    {
        public int PhotoID { get; set; }
        public string PhotoName { get; set; }



        public ICollection<Place> Place { get; set; }
    }
}
