using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestStore.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Album Album { get; set; }
        public int  Quantity { get; set; }


    }
}