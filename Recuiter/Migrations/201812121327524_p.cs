namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class p : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ActivationCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ActivationCode", c => c.Guid(nullable: false));
        }
    }
}
