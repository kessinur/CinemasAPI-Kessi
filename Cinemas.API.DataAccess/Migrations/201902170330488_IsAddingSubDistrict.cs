namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingSubDistrict : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubDistricts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Regencies_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regencies", t => t.Regencies_Id)
                .Index(t => t.Regencies_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubDistricts", "Regencies_Id", "dbo.Regencies");
            DropIndex("dbo.SubDistricts", new[] { "Regencies_Id" });
            DropTable("dbo.SubDistricts");
        }
    }
}
