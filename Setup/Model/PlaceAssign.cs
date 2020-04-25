using Setup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Setup.Models
{
    public class PlaceAssign
    {
        public int AccountID { get; set; }
        public int PlaceID { get; set; }
        public Account Account { get; set; }
        public Place Place { get; set; }
    }
}
