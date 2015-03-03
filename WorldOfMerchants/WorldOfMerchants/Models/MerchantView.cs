using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldOfMerchants.Models
{
    public class MerchantView
    {
        //public int ID { get; set; } // This was for using something in ItemsByMerchant view

        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public List<Item> Items { get; set; }
        public ItemCount ItemCount { get; set; }
    }

    public class ItemCount
    {
        public int itemCount { get; set; }
    }
}