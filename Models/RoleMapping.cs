using System.ComponentModel.DataAnnotations;
using TestStore.Dto;

namespace TestStore.Models
{
    public class RoleMapping
    {
        [Key]
        public virtual int RoleMappingID { get; set; }

        [Required]
        public virtual int EmployeeID { get; set; }

        [Required]
        public virtual int RoleID { get; set; }
        
        [Required]
        public int CustomerID { get; set; }

        //nav prop
        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
    }
}