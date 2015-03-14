namespace WorldOfMerchants.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "Email");
        }
    }
}
