namespace PFMO.Web.Migrations.PFMO_Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EquipmentModelUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentCategories",
                c => new
                    {
                        EquipmentCategoryID = c.Guid(nullable: false),
                        EquipmentCategoryName = c.String(nullable: false),
                        EquipmentCategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.EquipmentCategoryID);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentID = c.Guid(nullable: false),
                        EquipmentName = c.String(nullable: false),
                        EquipmentCategoryID = c.Guid(nullable: false),
                        EquipmentRemarks = c.String(),
                        EquipmentStatus = c.String(),
                        EquipmentBalance = c.Int(nullable: false),
                        EquipmentUnit = c.String(),
                        EquipmentReorderPoint = c.Int(nullable: false),
                        EquipmentExpiryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.EquipmentCategories", t => t.EquipmentCategoryID, cascadeDelete: true)
                .Index(t => t.EquipmentCategoryID);
            
            CreateTable(
                "dbo.EquipmentTargets",
                c => new
                    {
                        EquipmentTargetID = c.Guid(nullable: false),
                        EquipmentTargetName = c.String(nullable: false, maxLength: 200),
                        EquipmentTargetDescription = c.String(nullable: false),
                        EquipmentID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentTargetID)
                .ForeignKey("dbo.Equipments", t => t.EquipmentID, cascadeDelete: true)
                .Index(t => t.EquipmentID);
            
            CreateTable(
                "dbo.Personnels",
                c => new
                    {
                        PersonnelID = c.Guid(nullable: false),
                        PersonnelLastName = c.String(nullable: false),
                        PersonnelFirstName = c.String(nullable: false),
                        PersonnelPosition = c.String(),
                        SectionID = c.Guid(nullable: false),
                        ProjectTeamID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PersonnelID)
                .ForeignKey("dbo.ProjectTeams", t => t.ProjectTeamID, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .Index(t => t.SectionID)
                .Index(t => t.ProjectTeamID);
            
            CreateTable(
                "dbo.PersonnelTasks",
                c => new
                    {
                        PersonnelTaskID = c.Guid(nullable: false),
                        PersonnelTaskTitle = c.String(nullable: false, maxLength: 20),
                        PersonnelTaskDescription = c.String(maxLength: 30),
                        PersonnelID = c.Guid(nullable: false),
                        PersonnelTaskStartDate = c.DateTime(nullable: false),
                        PersonnelTaskEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonnelTaskID)
                .ForeignKey("dbo.Personnels", t => t.PersonnelID, cascadeDelete: true)
                .Index(t => t.PersonnelID);
            
            CreateTable(
                "dbo.ProjectTeams",
                c => new
                    {
                        ProjectTeamID = c.Guid(nullable: false),
                        ProjectTeamName = c.String(nullable: false, maxLength: 20),
                        ProjectTeamDescription = c.String(nullable: false, maxLength: 20),
                        ProjectID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectTeamID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Guid(nullable: false),
                        ProjectName = c.String(nullable: false, maxLength: 20),
                        ProjectDescription = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionID = c.Guid(nullable: false),
                        SectionName = c.String(nullable: false, maxLength: 20),
                        SectionType = c.String(nullable: false, maxLength: 15),
                        SectionDescription = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.SectionID);
            
            CreateTable(
                "dbo.SectionHeads",
                c => new
                    {
                        SectionHeadID = c.Guid(nullable: false),
                        SectionHeadLastName = c.String(nullable: false, maxLength: 20),
                        SectionHeadFirstName = c.String(nullable: false, maxLength: 20),
                        SectionHeadPosition = c.String(maxLength: 20),
                        SectionID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SectionHeadID)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .Index(t => t.SectionID);
            
            CreateTable(
                "dbo.SectionTasks",
                c => new
                    {
                        SectionTaskID = c.Guid(nullable: false),
                        SectionTaskTitle = c.String(nullable: false, maxLength: 20),
                        SectionTaskDescription = c.String(maxLength: 30),
                        SectionID = c.Guid(nullable: false),
                        SectionTaskStartDate = c.DateTime(nullable: false),
                        SectionTaskEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SectionTaskID)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .Index(t => t.SectionID);
            
            CreateTable(
                "dbo.Pinboards",
                c => new
                    {
                        PinboardID = c.Guid(nullable: false),
                        PinboardName = c.String(maxLength: 17),
                        PinboardContent = c.String(maxLength: 20),
                        PinboardDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PinboardID);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        SupplyID = c.Guid(nullable: false),
                        SupplyName = c.String(nullable: false),
                        SupplyCategoryID = c.Guid(nullable: false),
                        SupplyRemarks = c.String(),
                        SupplyStatus = c.String(),
                        SupplyBalance = c.Int(nullable: false),
                        SupplyUnit = c.String(),
                        SupplyReorderPoint = c.Int(nullable: false),
                        SupplyExpirydate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplyID)
                .ForeignKey("dbo.SupplyCategories", t => t.SupplyCategoryID, cascadeDelete: true)
                .Index(t => t.SupplyCategoryID);
            
            CreateTable(
                "dbo.SupplyCategories",
                c => new
                    {
                        SupplyCategoryID = c.Guid(nullable: false),
                        SupplyCategoryName = c.String(nullable: false),
                        SupplyCategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.SupplyCategoryID);
            
            CreateTable(
                "dbo.SupplyTargets",
                c => new
                    {
                        SupplyTargetID = c.Guid(nullable: false),
                        SupplyTargetName = c.String(nullable: false, maxLength: 20),
                        SupplyTargetDescription = c.String(nullable: false, maxLength: 20),
                        SupplyID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SupplyTargetID)
                .ForeignKey("dbo.Supplies", t => t.SupplyID, cascadeDelete: true)
                .Index(t => t.SupplyID);
            
            AlterColumn("dbo.Contacts", "ContactName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "ContactDescription", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacts", "ContactType", c => c.String(maxLength: 30));
            AlterColumn("dbo.Contacts", "ContactOffice", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplyTargets", "SupplyID", "dbo.Supplies");
            DropForeignKey("dbo.Supplies", "SupplyCategoryID", "dbo.SupplyCategories");
            DropForeignKey("dbo.SectionTasks", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.SectionHeads", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.Personnels", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.ProjectTeams", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Personnels", "ProjectTeamID", "dbo.ProjectTeams");
            DropForeignKey("dbo.PersonnelTasks", "PersonnelID", "dbo.Personnels");
            DropForeignKey("dbo.EquipmentTargets", "EquipmentID", "dbo.Equipments");
            DropForeignKey("dbo.Equipments", "EquipmentCategoryID", "dbo.EquipmentCategories");
            DropIndex("dbo.SupplyTargets", new[] { "SupplyID" });
            DropIndex("dbo.Supplies", new[] { "SupplyCategoryID" });
            DropIndex("dbo.SectionTasks", new[] { "SectionID" });
            DropIndex("dbo.SectionHeads", new[] { "SectionID" });
            DropIndex("dbo.ProjectTeams", new[] { "ProjectID" });
            DropIndex("dbo.PersonnelTasks", new[] { "PersonnelID" });
            DropIndex("dbo.Personnels", new[] { "ProjectTeamID" });
            DropIndex("dbo.Personnels", new[] { "SectionID" });
            DropIndex("dbo.EquipmentTargets", new[] { "EquipmentID" });
            DropIndex("dbo.Equipments", new[] { "EquipmentCategoryID" });
            AlterColumn("dbo.Contacts", "ContactOffice", c => c.String(maxLength: 16));
            AlterColumn("dbo.Contacts", "ContactType", c => c.String(maxLength: 16));
            AlterColumn("dbo.Contacts", "ContactDescription", c => c.String(maxLength: 20));
            AlterColumn("dbo.Contacts", "ContactName", c => c.String(maxLength: 17));
            DropTable("dbo.SupplyTargets");
            DropTable("dbo.SupplyCategories");
            DropTable("dbo.Supplies");
            DropTable("dbo.Pinboards");
            DropTable("dbo.SectionTasks");
            DropTable("dbo.SectionHeads");
            DropTable("dbo.Sections");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectTeams");
            DropTable("dbo.PersonnelTasks");
            DropTable("dbo.Personnels");
            DropTable("dbo.EquipmentTargets");
            DropTable("dbo.Equipments");
            DropTable("dbo.EquipmentCategories");
        }
    }
}
