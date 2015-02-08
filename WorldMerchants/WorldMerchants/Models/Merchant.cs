using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldMerchants.Models
{
    public class Merchant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}