namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreJobchanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "ContractLength");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "ContractLength", c => c.String(nullable: false));
        }
    }
}
