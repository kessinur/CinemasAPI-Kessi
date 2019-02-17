namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingProvinciesRegencies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provincies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Provincies_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincies", t => t.Provincies_Id)
                .Index(t => t.Provincies_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regencies", "Provincies_Id", "dbo.Provincies");
            DropIndex("dbo.Regencies", new[] { "Provincies_Id" });
            DropTable("dbo.Regencies");
            DropTable("dbo.Provincies");
        }
    }
}
