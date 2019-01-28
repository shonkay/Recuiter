namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Copy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Educations", "FromDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Educations", "ToDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Educations", "ToDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Educations", "FromDate", c => c.Int(nullable: false));
        }
    }
}
