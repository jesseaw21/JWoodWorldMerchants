using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldMerchants.Models
{
    public class Merchant
    {
        public int ID { get; set; }
        [Display(Name = "Merchant Name")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}