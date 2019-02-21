namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingBuyTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        FilmRooms_Id = c.Int(),
                        Reservations_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FilmRooms", t => t.FilmRooms_Id)
                .ForeignKey("dbo.Reservations", t => t.Reservations_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.FilmRooms_Id)
                .Index(t => t.Reservations_Id)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyTickets", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.BuyTickets", "Reservations_Id", "dbo.Reservations");
            DropForeignKey("dbo.BuyTickets", "FilmRooms_Id", "dbo.FilmRooms");
            DropIndex("dbo.BuyTickets", new[] { "Users_Id" });
            DropIndex("dbo.BuyTickets", new[] { "Reservations_Id" });
            DropIndex("dbo.BuyTickets", new[] { "FilmRooms_Id" });
            DropTable("dbo.BuyTickets");
        }
    }
}
