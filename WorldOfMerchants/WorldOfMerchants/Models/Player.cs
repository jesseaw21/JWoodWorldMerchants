using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldOfMerchants.Models
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        public int Score { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}