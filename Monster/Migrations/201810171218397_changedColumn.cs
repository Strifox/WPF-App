namespace Monster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false));
            DropColumn("dbo.Users", "AccountName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AccountName", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Username");
        }
    }
}
