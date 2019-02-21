namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingOrderProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Products_Id = c.Int(),
                        Reservations_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Products_Id)
                .ForeignKey("dbo.Reservations", t => t.Reservations_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Products_Id)
                .Index(t => t.Reservations_Id)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.OrderProducts", "Reservations_Id", "dbo.Reservations");
            DropForeignKey("dbo.OrderProducts", "Products_Id", "dbo.Products");
            DropIndex("dbo.OrderProducts", new[] { "Users_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Reservations_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Products_Id" });
            DropTable("dbo.OrderProducts");
        }
    }
}
