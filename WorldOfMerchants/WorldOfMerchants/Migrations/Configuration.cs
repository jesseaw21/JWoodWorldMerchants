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
                new Item{ID=1,Name="Wood Mallet", Rarity="Rare", Type="Weapon", Value=13, Points=6, MerchantID=1, PicUrl="woodmallet.png"},
                new Item{ID=2,Name="Ruby", Rarity="Uncommon", Type="Gem", Value=15, Points=7, MerchantID=2, PicUrl="ruby.jpg"},
                new Item{ID=3,Name="Bow", Rarity="Common", Type="Weapon", Value=13, Points=6, MerchantID=1, PicUrl="bow.jpg"},
                new Item{ID=4,Name="Emerald", Rarity="Common", Type="Gem", Value=15, Points=7, MerchantID=2, PicUrl="emerald.jpg"},
                new Item{ID=5,Name="Peridot", Rarity="Rare", Type="Gem", Value=13, Points=6, MerchantID=2, PicUrl="peridot.jpg"},
                new Item{ID=6,Name="Sword", Rarity="Uncommon", Type="Weapon", Value=15, Points=7, MerchantID=4, PicUrl="sword.jpg"},
                new Item{ID=7,Name="Shank", Rarity="Rare", Type="Weapon", Value=13, Points=6, MerchantID=4, PicUrl="shank.jpg"},
                new Item{ID=8,Name="Mace", Rarity="Uncommon", Type="Weapon", Value=15, Points=7, MerchantID=4, PicUrl="mace.jpg"},
                new Item{ID=9,Name="Amethyst", Rarity="Uncommon", Type="Mineral", Value=14, Points=6, MerchantID=3, PicUrl="amethyst.jpg"},
                new Item{ID=10,Name="Malachite", Rarity="Uncommon", Type="Mineral", Value=8, Points=3, MerchantID=3, PicUrl="malachite.jpg"},
            };

            items.ForEach(s => context.Items.AddOrUpdate(s));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player{ID=1,Name="Jones", Email ="jones@mail.com", DateStarted=DateTime.Now, Credits=40, Score=14},
                new Player{ID=2,Name="Harold", Email ="harold@mail.com", DateStarted=DateTime.Now, Credits=100, Score=12},
                new Player{ID=3,Name="Henry", Email ="henry@mail.com", DateStarted=DateTime.Now, Credits=20, Score=5}
            };

            players.ForEach(p => context.Players.AddOrUpdate(p));
            context.SaveChanges();

            var pictures = new List<Picture>
            {
                new Picture{ID=1,PictureURL = "woodmallet.png"}
            };

            pictures.ForEach(pc => context.Pictures.AddOrUpdate(pc));
            context.SaveChanges();
        }
    }
}
