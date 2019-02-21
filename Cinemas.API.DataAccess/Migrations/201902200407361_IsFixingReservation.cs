namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsFixingReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Users_Id", c => c.Int());
            CreateIndex("dbo.Reservations", "Users_Id");
            AddForeignKey("dbo.Reservations", "Users_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Users_Id", "dbo.Users");
            DropIndex("dbo.Reservations", new[] { "Users_Id" });
            DropColumn("dbo.Reservations", "Users_Id");
        }
    }
}
