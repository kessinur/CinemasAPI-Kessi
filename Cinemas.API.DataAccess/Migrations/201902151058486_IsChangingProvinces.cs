namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsChangingProvinces : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Provincies", newName: "Provinces");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Provinces", newName: "Provincies");
        }
    }
}
