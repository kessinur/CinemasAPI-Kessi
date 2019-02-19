namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingFilmRoom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilmRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShowDate = c.DateTime(nullable: false),
                        Hour = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FilmRooms");
        }
    }
}
