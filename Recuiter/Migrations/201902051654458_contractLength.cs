namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contractLength : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.JobViewModels", "ContractLength");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobViewModels", "ContractLength", c => c.String(nullable: false));
        }
    }
}
