namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class more : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "SkillSet", c => c.Int(nullable: false));
            AlterColumn("dbo.JobViewModels", "SkillSet", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobViewModels", "SkillSet", c => c.String(nullable: false));
            AlterColumn("dbo.Jobs", "SkillSet", c => c.String(nullable: false));
        }
    }
}
