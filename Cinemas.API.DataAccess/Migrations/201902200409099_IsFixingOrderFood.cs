namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsFixingOrderFood : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderProducts", "Users_Id", "dbo.Users");
            DropIndex("dbo.OrderProducts", new[] { "Users_Id" });
            DropColumn("dbo.OrderProducts", "Users_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderProducts", "Users_Id", c => c.Int());
            CreateIndex("dbo.OrderProducts", "Users_Id");
            AddForeignKey("dbo.OrderProducts", "Users_Id", "dbo.Users", "Id");
        }
    }
}
