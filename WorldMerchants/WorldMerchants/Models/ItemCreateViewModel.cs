using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WorldMerchants.Models
{
    public class ItemCreateViewModel
    {
            [Display(Name = "Item Name")]
            public string Name { get; set; }
            public string Rarity { get; set; }
            public string Type { get; set; }
            public int Value { get; set; }
            public int Points { get; set; }
            public Merchant Merchant { get; set; }
    }
}