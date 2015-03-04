namespace WorldOfMerchants.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "Credits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "Credits");
        }
    }
}
