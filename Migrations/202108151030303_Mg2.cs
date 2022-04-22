namespace Groupon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mg2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ShippingId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        AdresBasligi = c.String(nullable: false),
                        Adres = c.String(nullable: false),
                        Sehir = c.String(nullable: false),
                        Semt = c.String(nullable: false),
                        Mahalle = c.String(nullable: false),
                        PostaKodu = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShippingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShippingDetails");
        }
    }
}
