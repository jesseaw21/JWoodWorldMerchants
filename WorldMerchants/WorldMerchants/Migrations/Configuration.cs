namespace WorldMerchants.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WorldMerchants.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WorldMerchants.DAL.WorldContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WorldMerchants.DAL.WorldContext context)
        {
            var merchants = new List<Merchant>
            {
                new Merchant{Name="Overwood",Location="SouthWest Hills",Type="Wood Products"},
                new Merchant{Name="Underhill",Location="Under the Hill",Type="Gem Stones"},
                new Merchant{Name="The Mountain",Location="The Caves",Type="Minerals"},
                new Merchant{Name="Metalworks",Location="The Docks",Type="Forged Steel"}
            };

            merchants.ForEach(m => context.Merchants.AddOrUpdate(m));
            context.SaveChanges();

            var items = new List<Item>
            {
                new Item{Name="Wood Mallet", Rarity="Rare", Type="Weapon", Value=13, Points=6, MerchantID=merchants.Single(m => m.Name == "Overwood").ID},
                new Item{Name="Ruby", Rarity="Uncommon", Type="Gem", Value=15, Points=7, MerchantID=merchants.Single(m => m.Name == "Underhill").ID},
                new Item{Name="Bow", Rarity="Common", Type="Weapon", Value=13, Points=6, MerchantID=merchants.Single(m => m.Name == "Overwood").ID},
                new Item{Name="Emerald", Rarity="Common", Type="Gem", Value=15, Points=7, MerchantID=merchants.Single(m => m.Name == "Underhill").ID},
                new Item{Name="Peridot", Rarity="Rare", Type="Gem", Value=13, Points=6, MerchantID=merchants.Single(m => m.Name == "Underhill").ID},
                new Item{Name="Sword", Rarity="Uncommon", Type="Weapon", Value=15, Points=7, MerchantID=merchants.Single(m => m.Name == "Metalworks").ID},
                new Item{Name="Shank", Rarity="Rare", Type="Weapon", Value=13, Points=6, MerchantID=merchants.Single(m => m.Name == "Metalworks").ID},
                new Item{Name="Mace", Rarity="Uncommon", Type="Weapon", Value=15, Points=7, MerchantID=merchants.Single(m => m.Name == "Metalworks").ID},
                new Item{Name="Amethyst", Rarity="Uncommon", Type="Mineral", Value=14, Points=6, MerchantID=merchants.Single(m => m.Name == "The Mountain").ID},
                new Item{Name="Malachite", Rarity="Uncommon", Type="Mineral", Value=8, Points=3, MerchantID=merchants.Single(m => m.Name == "The Mountain").ID},
            };

            items.ForEach(s => context.Items.AddOrUpdate(s));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player{Name="Jones", DateStarted=DateTime.Now, Score=14},
                new Player{Name="Harold", DateStarted=DateTime.Now, Score=12},
                new Player{Name="Henry", DateStarted=DateTime.Now, Score=5}
            };

            players.ForEach(p => context.Players.AddOrUpdate(p));
            context.SaveChanges();

            var pictures = new List<Picture>
            {
                new Picture{PictureURL = "This"}
            };

            pictures.ForEach(pc => context.Pictures.AddOrUpdate(pc));
            context.SaveChanges();
        }
    }
}
