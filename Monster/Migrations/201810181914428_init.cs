namespace Monster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "AccessToken");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AccessToken", c => c.String());
        }
    }
}
