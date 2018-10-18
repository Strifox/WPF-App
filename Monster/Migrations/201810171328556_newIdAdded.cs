namespace Monster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newIdAdded : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Users", "Id");
            AddPrimaryKey("dbo.Users", "Username");
        }
    }
}
