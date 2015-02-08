using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldMerchants.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        public int Score { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}