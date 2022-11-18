namespace Prac_Contact_Directory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 30),
                        Address = c.String(),
                        Email = c.String(nullable: false, maxLength: 80),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ContactGroups",
                c => new
                    {
                        ContactGroupID = c.Int(nullable: false, identity: true),
                        ContactGroupName = c.String(nullable: false, maxLength: 40),
                        Title = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        Contact_EmployeeId = c.Int(),
                        Group_EmployeeId = c.Int(),
                        Group_ContactGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactGroupID)
                .ForeignKey("dbo.Contacts", t => t.Contact_EmployeeId)
                .ForeignKey("dbo.Groups", t => new { t.Group_EmployeeId, t.Group_ContactGroupId })
                .Index(t => t.Contact_EmployeeId)
                .Index(t => new { t.Group_EmployeeId, t.Group_ContactGroupId });
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        ContactGroupId = c.Int(nullable: false),
                        DepartmentCode = c.Int(nullable: false),
                        DistributionListName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ContactGroupId });
            
            CreateTable(
                "dbo.DistributionLists",
                c => new
                    {
                        DistributionListId = c.Int(nullable: false, identity: true),
                        DistributionListName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.DistributionListId);
            
            CreateTable(
                "dbo.DistributionListContacts",
                c => new
                    {
                        DistributionList_DistributionListId = c.Int(nullable: false),
                        Contact_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DistributionList_DistributionListId, t.Contact_EmployeeId })
                .ForeignKey("dbo.DistributionLists", t => t.DistributionList_DistributionListId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.Contact_EmployeeId, cascadeDelete: true)
                .Index(t => t.DistributionList_DistributionListId)
                .Index(t => t.Contact_EmployeeId);
            
            CreateTable(
                "dbo.DistributionListGroups",
                c => new
                    {
                        DistributionList_DistributionListId = c.Int(nullable: false),
                        Group_EmployeeId = c.Int(nullable: false),
                        Group_ContactGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DistributionList_DistributionListId, t.Group_EmployeeId, t.Group_ContactGroupId })
                .ForeignKey("dbo.DistributionLists", t => t.DistributionList_DistributionListId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => new { t.Group_EmployeeId, t.Group_ContactGroupId }, cascadeDelete: true)
                .Index(t => t.DistributionList_DistributionListId)
                .Index(t => new { t.Group_EmployeeId, t.Group_ContactGroupId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DistributionListGroups", new[] { "Group_EmployeeId", "Group_ContactGroupId" }, "dbo.Groups");
            DropForeignKey("dbo.DistributionListGroups", "DistributionList_DistributionListId", "dbo.DistributionLists");
            DropForeignKey("dbo.DistributionListContacts", "Contact_EmployeeId", "dbo.Contacts");
            DropForeignKey("dbo.DistributionListContacts", "DistributionList_DistributionListId", "dbo.DistributionLists");
            DropForeignKey("dbo.ContactGroups", new[] { "Group_EmployeeId", "Group_ContactGroupId" }, "dbo.Groups");
            DropForeignKey("dbo.ContactGroups", "Contact_EmployeeId", "dbo.Contacts");
            DropIndex("dbo.DistributionListGroups", new[] { "Group_EmployeeId", "Group_ContactGroupId" });
            DropIndex("dbo.DistributionListGroups", new[] { "DistributionList_DistributionListId" });
            DropIndex("dbo.DistributionListContacts", new[] { "Contact_EmployeeId" });
            DropIndex("dbo.DistributionListContacts", new[] { "DistributionList_DistributionListId" });
            DropIndex("dbo.ContactGroups", new[] { "Group_EmployeeId", "Group_ContactGroupId" });
            DropIndex("dbo.ContactGroups", new[] { "Contact_EmployeeId" });
            DropTable("dbo.DistributionListGroups");
            DropTable("dbo.DistributionListContacts");
            DropTable("dbo.DistributionLists");
            DropTable("dbo.Groups");
            DropTable("dbo.ContactGroups");
            DropTable("dbo.Contacts");
        }
    }
}
