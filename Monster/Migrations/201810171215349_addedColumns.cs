namespace Monster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AccountName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Salt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Salt");
            DropColumn("dbo.Users", "PasswordHash");
            DropColumn("dbo.Users", "AccountName");
        }
    }
}
