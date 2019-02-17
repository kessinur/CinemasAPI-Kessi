namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingCinema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Theaters_Id = c.Int(),
                        Villages_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Theaters", t => t.Theaters_Id)
                .ForeignKey("dbo.Villages", t => t.Villages_Id)
                .Index(t => t.Theaters_Id)
                .Index(t => t.Villages_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cinemas", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Cinemas", "Theaters_Id", "dbo.Theaters");
            DropIndex("dbo.Cinemas", new[] { "Villages_Id" });
            DropIndex("dbo.Cinemas", new[] { "Theaters_Id" });
            DropTable("dbo.Cinemas");
        }
    }
}
