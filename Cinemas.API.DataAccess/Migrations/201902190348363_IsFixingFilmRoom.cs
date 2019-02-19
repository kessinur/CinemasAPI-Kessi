namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsFixingFilmRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FilmRooms", "Films_Id", c => c.Int());
            AddColumn("dbo.FilmRooms", "Rooms_Id", c => c.Int());
            AlterColumn("dbo.FilmRooms", "Hour", c => c.String());
            CreateIndex("dbo.FilmRooms", "Films_Id");
            CreateIndex("dbo.FilmRooms", "Rooms_Id");
            AddForeignKey("dbo.FilmRooms", "Films_Id", "dbo.Films", "Id");
            AddForeignKey("dbo.FilmRooms", "Rooms_Id", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmRooms", "Rooms_Id", "dbo.Rooms");
            DropForeignKey("dbo.FilmRooms", "Films_Id", "dbo.Films");
            DropIndex("dbo.FilmRooms", new[] { "Rooms_Id" });
            DropIndex("dbo.FilmRooms", new[] { "Films_Id" });
            AlterColumn("dbo.FilmRooms", "Hour", c => c.DateTime(nullable: false));
            DropColumn("dbo.FilmRooms", "Rooms_Id");
            DropColumn("dbo.FilmRooms", "Films_Id");
        }
    }
}
