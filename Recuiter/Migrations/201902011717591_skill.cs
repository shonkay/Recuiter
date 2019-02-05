namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ProfilePictureUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ProfilePictureUrl");
        }
    }
}
