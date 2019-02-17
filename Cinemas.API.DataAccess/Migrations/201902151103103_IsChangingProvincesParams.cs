namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsChangingProvincesParams : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Regencies", name: "Provincies_Id", newName: "Provinces_Id");
            RenameIndex(table: "dbo.Regencies", name: "IX_Provincies_Id", newName: "IX_Provinces_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Regencies", name: "IX_Provinces_Id", newName: "IX_Provincies_Id");
            RenameColumn(table: "dbo.Regencies", name: "Provinces_Id", newName: "Provincies_Id");
        }
    }
}
