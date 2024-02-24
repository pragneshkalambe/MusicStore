using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestStore.Models
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string TotalAmount { get; set; }


        //public int OrderID { get; set; }
        //public DateTime OrderDate { get; set; }
        //public Album Album { get; set; }
        //public Item Item { get; set; }
        ////public int CodeCus{ get; set; }
        //public string Description { get; set; }
        //public Customer Customer { get; set; }

    }
}