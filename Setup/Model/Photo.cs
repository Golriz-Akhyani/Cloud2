using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Setup.Models
{

    public class Photo
    {
        public int PhotoID { get; set; }
        public string PhotoName { get; set; }
        public int PlaceID { get; set; }
        public byte[] PhotoBytes { get; set; }

       

    }
}
