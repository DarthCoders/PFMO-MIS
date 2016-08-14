namespace PFMO.Web.Migrations.PFMO_Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Models_Changed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EquipmentTargets", "EquipmentID", "dbo.Equipments");
            DropForeignKey("dbo.EquipmentTargets", "ProjectTargetID", "dbo.ProjectTargets");
            DropForeignKey("dbo.ProjectTargets", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.PersonnelJobTitles", "PersonnelID", "dbo.Personnels");
            DropForeignKey("dbo.SectionHeadJobTitles", "SectionHeadID", "dbo.SectionHeads");
            DropForeignKey("dbo.SupplyTargets", "ProjectTargetID", "dbo.ProjectTargets");
            DropForeignKey("dbo.SupplyTargets", "SupplyID", "dbo.Supplies");
            DropIndex("dbo.EquipmentTargets", new[] { "EquipmentID" });
            DropIndex("dbo.EquipmentTargets", new[] { "ProjectTargetID" });
            DropIndex("dbo.ProjectTargets", new[] { "ProjectID" });
            DropIndex("dbo.PersonnelJobTitles", new[] { "PersonnelID" });
            DropIndex("dbo.SectionHeadJobTitles", new[] { "SectionHeadID" });
            DropIndex("dbo.SupplyTargets", new[] { "SupplyID" });
            DropIndex("dbo.SupplyTargets", new[] { "ProjectTargetID" });
            CreateTable(
                "dbo.PersonnelDesignations",
                c => new
                    {
                        PersonnelDesignationID = c.Guid(nullable: false),
                        PersonnelDesignationName = c.String(nullable: false, maxLength: 200),
                        PersonnelDesignationDescription = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.PersonnelDesignationID);
            
            CreateTable(
                "dbo.SectionHeadDesignations",
                c => new
                    {
                        SectionHeadDesignationID = c.Guid(nullable: false),
                        SectionHeadDesignationName = c.String(nullable: false, maxLength: 200),
                        SectionHeadDesignationDescription = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.SectionHeadDesignationID);
            
            AddColumn("dbo.Equipments", "EquipmentCode", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Equipments", "Target", c => c.String(maxLength: 200));
            AddColumn("dbo.Equipments", "EquipmentxpiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Personnels", "PersonnelDesignationID", c => c.Guid(nullable: false));
            AddColumn("dbo.Personnels", "PersonnelContactNumber", c => c.Long(nullable: false));
            AddColumn("dbo.SectionHeads", "SectionHeadDesignationID", c => c.Guid(nullable: false));
            AddColumn("dbo.SectionHeads", "SectionHeadContactNumber", c => c.Long(nullable: false));
            AddColumn("dbo.Supplies", "SupplyCode", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Supplies", "Target", c => c.String(maxLength: 200));
            AddColumn("dbo.Supplies", "ProjectID", c => c.Guid(nullable: false));
            AlterColumn("dbo.PersonnelTasks", "PersonnelTaskStartDate", c => c.String());
            AlterColumn("dbo.PersonnelTasks", "PersonnelTaskEndDate", c => c.String());
            AlterColumn("dbo.SectionTasks", "SectionTaskStartDate", c => c.String());
            AlterColumn("dbo.SectionTasks", "SectionTaskEndDate", c => c.String());
            AlterColumn("dbo.Pinboards", "PinboardName", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.Personnels", "PersonnelDesignationID");
            CreateIndex("dbo.Supplies", "ProjectID");
            CreateIndex("dbo.SectionHeads", "SectionHeadDesignationID");
            AddForeignKey("dbo.Personnels", "PersonnelDesignationID", "dbo.PersonnelDesignations", "PersonnelDesignationID", cascadeDelete: true);
            AddForeignKey("dbo.Supplies", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.SectionHeads", "SectionHeadDesignationID", "dbo.SectionHeadDesignations", "SectionHeadDesignationID", cascadeDelete: true);
            DropColumn("dbo.Equipments", "EquipmentExpiryDate");
            DropTable("dbo.EquipmentTargets");
            DropTable("dbo.ProjectTargets");
            DropTable("dbo.PersonnelJobTitles");
            DropTable("dbo.SectionHeadJobTitles");
            DropTable("dbo.SupplyTargets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SupplyTargets",
                c => new
                    {
                        SupplyTargetID = c.Guid(nullable: false),
                        SupplyTargetName = c.String(nullable: false, maxLength: 200),
                        SupplyTargetDescription = c.String(maxLength: 200),
                        SupplyID = c.Guid(nullable: false),
                        ProjectTargetID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SupplyTargetID);
            
            CreateTable(
                "dbo.SectionHeadJobTitles",
                c => new
                    {
                        SectionHeadJobTitleID = c.Guid(nullable: false),
                        SectionHeadJobTitleName = c.String(nullable: false, maxLength: 200),
                        SectionHeadJobTitleDescription = c.String(maxLength: 500),
                        SectionHeadID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SectionHeadJobTitleID);
            
            CreateTable(
                "dbo.PersonnelJobTitles",
                c => new
                    {
                        PersonnelJobTitleID = c.Guid(nullable: false),
                        PersonnelJobTitleName = c.String(nullable: false, maxLength: 200),
                        PersonnelJobTitleDescription = c.String(maxLength: 500),
                        PersonnelID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PersonnelJobTitleID);
            
            CreateTable(
                "dbo.ProjectTargets",
                c => new
                    {
                        ProjectTargetID = c.Guid(nullable: false),
                        ProjectTargetName = c.String(nullable: false, maxLength: 200),
                        SupplyTargetDescription = c.String(maxLength: 200),
                        ProjectID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectTargetID);
            
            CreateTable(
                "dbo.EquipmentTargets",
                c => new
                    {
                        EquipmentTargetID = c.Guid(nullable: false),
                        EquipmentTargetName = c.String(nullable: false, maxLength: 200),
                        EquipmentTargetDescription = c.String(maxLength: 200),
                        EquipmentID = c.Guid(nullable: false),
                        ProjectTargetID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentTargetID);
            
            AddColumn("dbo.Equipments", "EquipmentExpiryDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.SectionHeads", "SectionHeadDesignationID", "dbo.SectionHeadDesignations");
            DropForeignKey("dbo.Supplies", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Personnels", "PersonnelDesignationID", "dbo.PersonnelDesignations");
            DropIndex("dbo.SectionHeads", new[] { "SectionHeadDesignationID" });
            DropIndex("dbo.Supplies", new[] { "ProjectID" });
            DropIndex("dbo.Personnels", new[] { "PersonnelDesignationID" });
            AlterColumn("dbo.Pinboards", "PinboardName", c => c.String(maxLength: 200));
            AlterColumn("dbo.SectionTasks", "SectionTaskEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SectionTasks", "SectionTaskStartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PersonnelTasks", "PersonnelTaskEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PersonnelTasks", "PersonnelTaskStartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Supplies", "ProjectID");
            DropColumn("dbo.Supplies", "Target");
            DropColumn("dbo.Supplies", "SupplyCode");
            DropColumn("dbo.SectionHeads", "SectionHeadContactNumber");
            DropColumn("dbo.SectionHeads", "SectionHeadDesignationID");
            DropColumn("dbo.Personnels", "PersonnelContactNumber");
            DropColumn("dbo.Personnels", "PersonnelDesignationID");
            DropColumn("dbo.Equipments", "EquipmentxpiryDate");
            DropColumn("dbo.Equipments", "Target");
            DropColumn("dbo.Equipments", "EquipmentCode");
            DropTable("dbo.SectionHeadDesignations");
            DropTable("dbo.PersonnelDesignations");
            CreateIndex("dbo.SupplyTargets", "ProjectTargetID");
            CreateIndex("dbo.SupplyTargets", "SupplyID");
            CreateIndex("dbo.SectionHeadJobTitles", "SectionHeadID");
            CreateIndex("dbo.PersonnelJobTitles", "PersonnelID");
            CreateIndex("dbo.ProjectTargets", "ProjectID");
            CreateIndex("dbo.EquipmentTargets", "ProjectTargetID");
            CreateIndex("dbo.EquipmentTargets", "EquipmentID");
            AddForeignKey("dbo.SupplyTargets", "SupplyID", "dbo.Supplies", "SupplyID", cascadeDelete: true);
            AddForeignKey("dbo.SupplyTargets", "ProjectTargetID", "dbo.ProjectTargets", "ProjectTargetID", cascadeDelete: true);
            AddForeignKey("dbo.SectionHeadJobTitles", "SectionHeadID", "dbo.SectionHeads", "SectionHeadID", cascadeDelete: true);
            AddForeignKey("dbo.PersonnelJobTitles", "PersonnelID", "dbo.Personnels", "PersonnelID", cascadeDelete: true);
            AddForeignKey("dbo.ProjectTargets", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.EquipmentTargets", "ProjectTargetID", "dbo.ProjectTargets", "ProjectTargetID", cascadeDelete: true);
            AddForeignKey("dbo.EquipmentTargets", "EquipmentID", "dbo.Equipments", "EquipmentID", cascadeDelete: true);
        }
    }
}
