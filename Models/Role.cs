using System;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace TestStore.Models
{
    public class Role
    {
        [Key]
        public virtual int RoleId { get; set; }

        [Required]
        public virtual string Name { get; set; }
    }
}