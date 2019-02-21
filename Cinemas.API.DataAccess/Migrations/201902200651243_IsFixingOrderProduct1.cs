namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsFixingOrderProduct1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderProducts", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderProducts", "Quantity", c => c.Int(nullable: false));
        }
    }
}
