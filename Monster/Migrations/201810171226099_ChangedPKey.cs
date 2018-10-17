namespace Monster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "Username");
            DropColumn("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
