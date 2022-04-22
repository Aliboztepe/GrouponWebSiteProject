namespace Groupon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mg4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "passwordAgain", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "passwordAgain");
        }
    }
}
