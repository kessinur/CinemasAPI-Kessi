namespace Cinemas.API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingSecretUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SecretQuestion", c => c.String());
            AddColumn("dbo.Users", "SecretAnswer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "SecretAnswer");
            DropColumn("dbo.Users", "SecretQuestion");
        }
    }
}
