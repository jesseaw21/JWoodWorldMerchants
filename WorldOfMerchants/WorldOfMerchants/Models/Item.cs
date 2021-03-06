﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldOfMerchants.Models
{
    public class Item : IEntity
    {
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? MerchantID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? PlayerID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? PictureID { get; set; }

        [StringLength(35)]
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Type { get; set; }
        [Range(0, 100)]
        public int Value { get; set; }
        [Range(0, 20)]
        public int Points { get; set; }
        public string PicUrl { get; set; }
    }
}