namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicantResumeProfile : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Experiences", "FromDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Experiences", "ToDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Experiences", "ToDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Experiences", "FromDate", c => c.Int(nullable: false));
        }
    }
}
