using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WorldMerchants.Models;

namespace WorldMerchants.DAL
{
    //public class WorldInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WorldContext>
    public class WorldInitializer : System.Data.Entity.DropCreateDatabaseAlways<WorldContext>
    {
        protected override void Seed(WorldContext context)
        {
            var merchants = new List<Merchant>
            {
                new Merchant{Name="Overwood",Location="SouthWest Hills",Type="Wooden Products"},
                new Merchant{Name="Underhill",Location="Under the Hill",Type="Gem Stones"}
            };

            merchants.ForEach(m => context.Merchants.Add(m));
            context.SaveChanges();

            var items = new List<Item>
            {
                new Item{Name="Wood Mallet", Rarity="Rare", Type="Mallet", Value=13, Points=6, Magic=2, MerchantID=1},
                new Item{Name="Ruby", Rarity="Uncommon", Type="Gem", Value=15, Points=7, Magic=3, MerchantID=1}
            };

            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player{Name="Jones", DateStarted=DateTime.Now, Score=14}
            };

            players.ForEach(p => context.Players.Add(p));
            context.SaveChanges();

            var pictures = new List<Picture>
            {
                new Picture{PictureURL = "This"}
            };

            pictures.ForEach(pc => context.Pictures.Add(pc));
            context.SaveChanges();
        }
    }
}