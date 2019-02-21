namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsFixingBuyTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BuyTickets", "Users_Id", "dbo.Users");
            DropIndex("dbo.BuyTickets", new[] { "Users_Id" });
            DropColumn("dbo.BuyTickets", "Users_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuyTickets", "Users_Id", c => c.Int());
            CreateIndex("dbo.BuyTickets", "Users_Id");
            AddForeignKey("dbo.BuyTickets", "Users_Id", "dbo.Users", "Id");
        }
    }
}
