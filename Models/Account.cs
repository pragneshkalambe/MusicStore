using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestStore.Models;

namespace TestStore.Dto
{
    public class Account
    {
        public int AccountID { get; set; }
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        public Customer Customer { get; set; }
    }
}