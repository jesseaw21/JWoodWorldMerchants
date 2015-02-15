using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldMerchants.Models
{
    public class ItemCreateViewModel
    {
            public string Name { get; set; }
            public string Rarity { get; set; }
            public string Type { get; set; }
            public int Value { get; set; }
            public int Points { get; set; }
            public int Magic { get; set; }
            public Merchant Merchant { get; set; }
    }
}