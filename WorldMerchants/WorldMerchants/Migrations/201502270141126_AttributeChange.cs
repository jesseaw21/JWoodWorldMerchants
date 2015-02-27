namespace WorldMerchants.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttributeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Rarity", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Rarity", c => c.String(nullable: false));
        }
    }
}
