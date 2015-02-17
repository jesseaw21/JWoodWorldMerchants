using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldMerchants.Models
{
    public class Item
    {
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? MerchantID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? PlayerID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? PictureID { get; set; }

        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public int Points { get; set; }
    }
}