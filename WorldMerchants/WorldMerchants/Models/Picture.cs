using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldMerchants.Models
{
    public class Picture
    {
        public int ID { get; set; }
        public string PictureURL { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}