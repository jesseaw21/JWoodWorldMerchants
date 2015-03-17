namespace WorldOfMerchants.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "PicUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "PicUrl");
        }
    }
}
