namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingRestaurant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Cinemas_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.Cinemas_Id)
                .Index(t => t.Cinemas_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "Cinemas_Id", "dbo.Cinemas");
            DropIndex("dbo.Restaurants", new[] { "Cinemas_Id" });
            DropTable("dbo.Restaurants");
        }
    }
}
