namespace PFMO.Web.Migrations.PFMO_Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllModelUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectTargets",
                c => new
                    {
                        ProjectTargetID = c.Guid(nullable: false),
                        ProjectTargetName = c.String(nullable: false, maxLength: 200),
                        SupplyTargetDescription = c.String(maxLength: 200),
                        ProjectID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectTargetID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            AddColumn("dbo.EquipmentTargets", "ProjectTargetID", c => c.Guid(nullable: false));
            AddColumn("dbo.Projects", "ProjectStatus", c => c.String(maxLength: 200));
            AddColumn("dbo.Projects", "ProjectStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "ProjectEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "ProjectCompletion", c => c.Int(nullable: false));
            AddColumn("dbo.SupplyTargets", "ProjectTargetID", c => c.Guid(nullable: false));
            AlterColumn("dbo.EquipmentCategories", "EquipmentCategoryName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.EquipmentCategories", "EquipmentCategoryDescription", c => c.String(maxLength: 200));
            AlterColumn("dbo.Equipments", "EquipmentName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Equipments", "EquipmentRemarks", c => c.String(maxLength: 200));
            AlterColumn("dbo.Equipments", "EquipmentStatus", c => c.String(maxLength: 200));
            AlterColumn("dbo.Equipments", "EquipmentUnit", c => c.String(maxLength: 200));
            AlterColumn("dbo.EquipmentTargets", "EquipmentTargetDescription", c => c.String(maxLength: 200));
            AlterColumn("dbo.Personnels", "PersonnelLastName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Personnels", "PersonnelFirstName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Personnels", "PersonnelPosition", c => c.String(maxLength: 200));
            AlterColumn("dbo.PersonnelTasks", "PersonnelTaskTitle", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.PersonnelTasks", "PersonnelTaskDescription", c => c.String(maxLength: 200));
            AlterColumn("dbo.ProjectTeams", "ProjectTeamDescription", c => c.String(maxLength: 20));
            AlterColumn("dbo.Projects", "ProjectName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Sections", "SectionName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Sections", "SectionType", c => c.String(maxLength: 200));
            AlterColumn("dbo.Sections", "SectionDescription", c => c.String(maxLength: 200));
            AlterColumn("dbo.SectionHeads", "SectionHeadLastName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.SectionHeads", "SectionHeadFirstName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.SectionHeads", "SectionHeadPosition", c => c.String(maxLength: 200));
            AlterColumn("dbo.SectionTasks", "SectionTaskTitle", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.SectionTasks", "SectionTaskDescription", c => c.String(maxLength: 200));
            AlterColumn("dbo.Pinboards", "PinboardName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Pinboards", "PinboardContent", c => c.String(maxLength: 200));
            AlterColumn("dbo.Supplies", "SupplyName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Supplies", "SupplyRemarks", c => c.String(maxLength: 200));
            AlterColumn("dbo.Supplies", "SupplyStatus", c => c.String(maxLength: 200));
            AlterColumn("dbo.Supplies", "SupplyUnit", c => c.String(maxLength: 200));
            AlterColumn("dbo.SupplyCategories", "SupplyCategoryName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.SupplyCategories", "SupplyCategoryDescription", c => c.String(maxLength: 200));
            AlterColumn("dbo.SupplyTargets", "SupplyTargetName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.SupplyTargets", "SupplyTargetDescription", c => c.String(maxLength: 200));
            CreateIndex("dbo.EquipmentTargets", "ProjectTargetID");
            CreateIndex("dbo.SupplyTargets", "ProjectTargetID");
            AddForeignKey("dbo.EquipmentTargets", "ProjectTargetID", "dbo.ProjectTargets", "ProjectTargetID", cascadeDelete: true);
            AddForeignKey("dbo.SupplyTargets", "ProjectTargetID", "dbo.ProjectTargets", "ProjectTargetID", cascadeDelete: true);
            DropColumn("dbo.Projects", "ProjectDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ProjectDescription", c => c.String(maxLength: 20));
            DropForeignKey("dbo.SupplyTargets", "ProjectTargetID", "dbo.ProjectTargets");
            DropForeignKey("dbo.ProjectTargets", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.EquipmentTargets", "ProjectTargetID", "dbo.ProjectTargets");
            DropIndex("dbo.SupplyTargets", new[] { "ProjectTargetID" });
            DropIndex("dbo.ProjectTargets", new[] { "ProjectID" });
            DropIndex("dbo.EquipmentTargets", new[] { "ProjectTargetID" });
            AlterColumn("dbo.SupplyTargets", "SupplyTargetDescription", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.SupplyTargets", "SupplyTargetName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.SupplyCategories", "SupplyCategoryDescription", c => c.String());
            AlterColumn("dbo.SupplyCategories", "SupplyCategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Supplies", "SupplyUnit", c => c.String());
            AlterColumn("dbo.Supplies", "SupplyStatus", c => c.String());
            AlterColumn("dbo.Supplies", "SupplyRemarks", c => c.String());
            AlterColumn("dbo.Supplies", "SupplyName", c => c.String(nullable: false));
            AlterColumn("dbo.Pinboards", "PinboardContent", c => c.String(maxLength: 20));
            AlterColumn("dbo.Pinboards", "PinboardName", c => c.String(maxLength: 17));
            AlterColumn("dbo.SectionTasks", "SectionTaskDescription", c => c.String(maxLength: 30));
            AlterColumn("dbo.SectionTasks", "SectionTaskTitle", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.SectionHeads", "SectionHeadPosition", c => c.String(maxLength: 20));
            AlterColumn("dbo.SectionHeads", "SectionHeadFirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.SectionHeads", "SectionHeadLastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Sections", "SectionDescription", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Sections", "SectionType", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Sections", "SectionName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Projects", "ProjectName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ProjectTeams", "ProjectTeamDescription", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.PersonnelTasks", "PersonnelTaskDescription", c => c.String(maxLength: 30));
            AlterColumn("dbo.PersonnelTasks", "PersonnelTaskTitle", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Personnels", "PersonnelPosition", c => c.String());
            AlterColumn("dbo.Personnels", "PersonnelFirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Personnels", "PersonnelLastName", c => c.String(nullable: false));
            AlterColumn("dbo.EquipmentTargets", "EquipmentTargetDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Equipments", "EquipmentUnit", c => c.String());
            AlterColumn("dbo.Equipments", "EquipmentStatus", c => c.String());
            AlterColumn("dbo.Equipments", "EquipmentRemarks", c => c.String());
            AlterColumn("dbo.Equipments", "EquipmentName", c => c.String(nullable: false));
            AlterColumn("dbo.EquipmentCategories", "EquipmentCategoryDescription", c => c.String());
            AlterColumn("dbo.EquipmentCategories", "EquipmentCategoryName", c => c.String(nullable: false));
            DropColumn("dbo.SupplyTargets", "ProjectTargetID");
            DropColumn("dbo.Projects", "ProjectCompletion");
            DropColumn("dbo.Projects", "ProjectEndDate");
            DropColumn("dbo.Projects", "ProjectStartDate");
            DropColumn("dbo.Projects", "ProjectStatus");
            DropColumn("dbo.EquipmentTargets", "ProjectTargetID");
            DropTable("dbo.ProjectTargets");
        }
    }
}
