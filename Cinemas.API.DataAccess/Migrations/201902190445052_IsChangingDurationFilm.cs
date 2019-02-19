namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsChangingDurationFilm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "Duration", c => c.String());
        }
    }
}
