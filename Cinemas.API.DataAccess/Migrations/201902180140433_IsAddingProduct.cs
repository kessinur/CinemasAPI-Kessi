namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Variety = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Price = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Restaurants_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurants_Id)
                .Index(t => t.Restaurants_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Restaurants_Id", "dbo.Restaurants");
            DropIndex("dbo.Products", new[] { "Restaurants_Id" });
            DropTable("dbo.Products");
        }
    }
}
