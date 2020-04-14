using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Setup.Models
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "First Name cannot be longer than 30 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Last Name cannot be longer than 30 characters.")]
        public string LastName { get; set; }

        public string CompanyName { get; set; }
        public string Email { get; set; }

     
        public string Telephone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

  
        public string Province { get; set; }

    
        public string ZipCode { get; set; }
        public string UserName { get; set; }

    }
}