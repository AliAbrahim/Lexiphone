namespace Lexiphone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saddoo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductUrl", c => c.String());
            AlterColumn("dbo.Products", "CurrentPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "CurrentPrice", c => c.Single(nullable: false));
            DropColumn("dbo.Products", "ProductUrl");
        }
    }
}
