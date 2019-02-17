namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingVillage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Villages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        SubDistricts_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubDistricts", t => t.SubDistricts_Id)
                .Index(t => t.SubDistricts_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Villages", "SubDistricts_Id", "dbo.SubDistricts");
            DropIndex("dbo.Villages", new[] { "SubDistricts_Id" });
            DropTable("dbo.Villages");
        }
    }
}
