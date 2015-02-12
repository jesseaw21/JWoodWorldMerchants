using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WorldMerchants.Models;

namespace WorldMerchants.DAL
{
    public class WorldInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WorldContext>
    //public class WorldInitializer : System.Data.Entity.DropCreateDatabaseAlways<WorldContext>
    {
        protected override void Seed(WorldContext context)
        {
            var merchants = new List<Merchant>
            {
                new Merchant{Name="Overwood",Location="SouthWest Hills",Type="Wood Products"},
                new Merchant{Name="Underhill",Location="Under the Hill",Type="Gem Stones"},
                new Merchant{Name="The Mountain",Location="The Caves",Type="Jewels"},
                new Merchant{Name="Metalworks",Location="The Docks",Type="Forged Steel"}
            };

            merchants.ForEach(m => context.Merchants.Add(m));
            context.SaveChanges();

            var items = new List<Item>
            {
                new Item{Name="Wood Mallet", Rarity="Rare", Type="Weapon", Value=13, Points=6, Magic=2, MerchantID=1},
                new Item{Name="Ruby", Rarity="Uncommon", Type="Gem", Value=15, Points=7, Magic=3, MerchantID=2},
                new Item{Name="Bow", Rarity="Common", Type="Weapon", Value=13, Points=6, Magic=2, MerchantID=1},
                new Item{Name="Emerald", Rarity="Common", Type="Gem", Value=15, Points=7, Magic=3, MerchantID=2},
                new Item{Name="Peridot", Rarity="Rare", Type="Gem", Value=13, Points=6, Magic=2, MerchantID=2},
                new Item{Name="Sword", Rarity="Uncommon", Type="Weapon", Value=15, Points=7, Magic=3, MerchantID=4},
                new Item{Name="Shank", Rarity="Rare", Type="Weapon", Value=13, Points=6, Magic=2, MerchantID=4},
                new Item{Name="Mace", Rarity="Uncommon", Type="Weapon", Value=15, Points=7, Magic=3, MerchantID=4},
            };

            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player{Name="Jones", DateStarted=DateTime.Now, Score=14},
                new Player{Name="Harold", DateStarted=DateTime.Now, Score=12},
                new Player{Name="Henry", DateStarted=DateTime.Now, Score=5}
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