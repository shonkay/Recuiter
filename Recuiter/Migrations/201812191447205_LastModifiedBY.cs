namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastModifiedBY : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "LastModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LastModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
