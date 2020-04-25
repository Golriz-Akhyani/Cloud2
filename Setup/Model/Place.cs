using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Setup.Models
{

    public class Place
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaceID { get; set; }

        [StringLength(50, ErrorMessage = "Place Name cannot be longer than 50 characters.")]
        public string PlaceName { get; set; }

        [Display(Name = "License Number")]
        [StringLength(8, ErrorMessage = "License Number is A with 7 Digital Number.")]
        public string License { get; set; }
       
        public string Address { get; set; }
        public bool Wifi { get; set; }
        public bool Whiteboard { get; set; }
        public bool ParkingLot { get; set; }
        public bool Washroom { get; set; }
        public string Description { get; set; }

        public ICollection<Photo> PhotoID { get; set; }
        public ICollection<PlaceAssign> PlaceAssigns { get; set; }


        public int? AccountID { get; set; }
        public Account Administrator { get; set; }

    }
}