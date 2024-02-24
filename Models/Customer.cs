using System.ComponentModel.DataAnnotations;

namespace TestStore.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "FirstName Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName Required")]


        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone Number Required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        public int CodeCus { get; set; }


    }
}