namespace WorldOfMerchants.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WorldOfMerchants.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WorldOfMerchants.DAL.WorldContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WorldOfMerchants.DAL.WorldContext context)
        {
            var merchants = new List<Merchant>
            {
                new Merchant{ID=1,Name="Overwood",Location="SouthWest Hills",Type="Wood Products"},
                new Merchant{ID=2,Name="Underhill",Location="Under the Hill",Type="Gem Stones"},
                new Merchant{ID=3,Name="The Mountain",Location="The Caves",Type="Minerals"},
                new Merchant{ID=4,Name="Metalworks",Location="The Docks",Type="Forged Steel"}
            };

            merchants.ForEach(m => context.Merchants.AddOrUpdate(m));
            context.SaveChanges();

            var items = new List<Item>
            {
                new Item{ID=1,Name="Wood Mallet", Rarity="Rare", Type="Weapon", Value=13, Points=6, MerchantID=1},
                new Item{ID=2,Name="Ruby", Rarity="Uncommon", Type="Gem", Value=15, Points=7, MerchantID=2},
                new Item{ID=3,Name="Bow", Rarity="Common", Type="Weapon", Value=13, Points=6, MerchantID=1},
                new Item{ID=4,Name="Emerald", Rarity="Common", Type="Gem", Value=15, Points=7, MerchantID=2},
                new Item{ID=5,Name="Peridot", Rarity="Rare", Type="Gem", Value=13, Points=6, MerchantID=2},
                new Item{ID=6,Name="Sword", Rarity="Uncommon", Type="Weapon", Value=15, Points=7, MerchantID=4},
                new Item{ID=7,Name="Shank", Rarity="Rare", Type="Weapon", Value=13, Points=6, MerchantID=4},
                new Item{ID=8,Name="Mace", Rarity="Uncommon", Type="Weapon", Value=15, Points=7, MerchantID=4},
                new Item{ID=9,Name="Amethyst", Rarity="Uncommon", Type="Mineral", Value=14, Points=6, MerchantID=3},
                new Item{ID=10,Name="Malachite", Rarity="Uncommon", Type="Mineral", Value=8, Points=3, MerchantID=3},
            };

            items.ForEach(s => context.Items.AddOrUpdate(s));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player{ID=1,Name="Jones", DateStarted=DateTime.Now, Score=14},
                new Player{ID=2,Name="Harold", DateStarted=DateTime.Now, Score=12},
                new Player{ID=3,Name="Henry", DateStarted=DateTime.Now, Score=5}
            };

            players.ForEach(p => context.Players.AddOrUpdate(p));
            context.SaveChanges();

            var pictures = new List<Picture>
            {
                new Picture{ID=1,PictureURL = "This"}
            };

            pictures.ForEach(pc => context.Pictures.AddOrUpdate(pc));
            context.SaveChanges();
        }
    }
}
