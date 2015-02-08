using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldMerchants.Models
{
    public class Item
    {
        public int ID { get; set; }

        //public Merchant MerchantID { get; set; }
        //public Player PlayerID { get; set; }
        //public Picture PictureID { get; set; }

        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public int Points { get; set; }
        public int Magic { get; set; }

        public virtual Merchant Merchant { get; set; }
        public virtual Player Player { get; set; }
        public virtual Picture Picture { get; set; }
    }
}