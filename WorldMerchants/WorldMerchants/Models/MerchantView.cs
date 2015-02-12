using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldMerchants.Models
{
    public class MerchantView
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public ItemCount ItemCount { get; set; }
    }

    public class ItemCount
    {
        public int itemCount { get; set; }
    }
}