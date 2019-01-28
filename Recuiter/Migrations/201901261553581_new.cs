namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Educations", "FromDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Educations", "ToDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Experiences", "FromDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Experiences", "ToDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Experiences", "ToDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Experiences", "FromDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Educations", "ToDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Educations", "FromDate", c => c.Int(nullable: false));
        }
    }
}
