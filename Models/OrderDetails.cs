using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestStore.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int AlbumID { get; set; }
        public Item Item { get; set; }



    }
}