namespace Groupon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShippingDetails", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShippingDetails", "FullName", c => c.String());
        }
    }
}
