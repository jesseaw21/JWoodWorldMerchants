using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldOfMerchants.Models
{
    public class Picture
    {
        public int ID { get; set; }
        public string PictureURL { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}