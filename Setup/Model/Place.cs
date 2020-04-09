using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Setup.Models
{

    public class Place
    {
        public int PlaceID { get; set; }
        public string PlaceName { get; set; }
        public string Liscence { get; set; }
        public string Address { get; set; }
        public bool Wifi { get; set; }
        public bool Whiteboard { get; set; }
        public bool ParkingLot { get; set; }
        public bool Washroom { get; set; }
        public string Description { get; set; }


        public ICollection<Account> Account { get; set; }
        public ICollection<Photo> Photos { get; set; }
      
    }
}
