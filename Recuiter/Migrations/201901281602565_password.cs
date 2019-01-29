namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class password : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "OldPassword", c => c.String());
            AddColumn("dbo.Users", "NewPassword", c => c.String());
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ConfirmPassword");
            DropColumn("dbo.Users", "NewPassword");
            DropColumn("dbo.Users", "OldPassword");
        }
    }
}
