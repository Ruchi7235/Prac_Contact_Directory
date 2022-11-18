namespace Prac_Contact_Directory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialIgnoreChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "GroupName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groups", "GroupName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
