namespace WorldOfMerchants.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        MerchantID = c.Int(),
                        PlayerID = c.Int(),
                        PictureID = c.Int(),
                        Name = c.String(maxLength: 35),
                        Rarity = c.String(),
                        Type = c.String(nullable: false),
                        Value = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Merchant", t => t.MerchantID)
                .ForeignKey("dbo.Picture", t => t.PictureID)
                .ForeignKey("dbo.Player", t => t.PlayerID)
                .Index(t => t.MerchantID)
                .Index(t => t.PlayerID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Merchant",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        Location = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        PictureURL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        DateStarted = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.Item", "PictureID", "dbo.Picture");
            DropForeignKey("dbo.Item", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.Item", new[] { "PictureID" });
            DropIndex("dbo.Item", new[] { "PlayerID" });
            DropIndex("dbo.Item", new[] { "MerchantID" });
            DropTable("dbo.Player");
            DropTable("dbo.Picture");
            DropTable("dbo.Merchant");
            DropTable("dbo.Item");
        }
    }
}
