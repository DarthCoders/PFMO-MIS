namespace PFMO.Web.Migrations.PFMO_Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalModelUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonnelJobTitles",
                c => new
                    {
                        PersonnelJobTitleID = c.Guid(nullable: false),
                        PersonnelJobTitleName = c.String(nullable: false, maxLength: 200),
                        PersonnelJobTitleDescription = c.String(maxLength: 500),
                        PersonnelID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PersonnelJobTitleID)
                .ForeignKey("dbo.Personnels", t => t.PersonnelID, cascadeDelete: true)
                .Index(t => t.PersonnelID);
            
            CreateTable(
                "dbo.SectionHeadJobTitles",
                c => new
                    {
                        SectionHeadJobTitleID = c.Guid(nullable: false),
                        SectionHeadJobTitleName = c.String(nullable: false, maxLength: 200),
                        SectionHeadJobTitleDescription = c.String(maxLength: 500),
                        SectionHeadID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SectionHeadJobTitleID)
                .ForeignKey("dbo.SectionHeads", t => t.SectionHeadID, cascadeDelete: true)
                .Index(t => t.SectionHeadID);
            
            AddColumn("dbo.Personnels", "PersonnelGender", c => c.String(maxLength: 10));
            AddColumn("dbo.Personnels", "PersonnelRemarks", c => c.String(maxLength: 200));
            AddColumn("dbo.Personnels", "PersonnelHireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sections", "SectionDateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.SectionHeads", "SectionHeadGender", c => c.String(maxLength: 10));
            AddColumn("dbo.SectionHeads", "SectionHeadRemarks", c => c.String(maxLength: 200));
            AddColumn("dbo.SectionHeads", "SectionHeadHireDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectTeams", "ProjectTeamName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ProjectTeams", "ProjectTeamDescription", c => c.String(maxLength: 200));
            DropColumn("dbo.Personnels", "PersonnelPosition");
            DropColumn("dbo.SectionHeads", "SectionHeadPosition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SectionHeads", "SectionHeadPosition", c => c.String(maxLength: 200));
            AddColumn("dbo.Personnels", "PersonnelPosition", c => c.String(maxLength: 200));
            DropForeignKey("dbo.SectionHeadJobTitles", "SectionHeadID", "dbo.SectionHeads");
            DropForeignKey("dbo.PersonnelJobTitles", "PersonnelID", "dbo.Personnels");
            DropIndex("dbo.SectionHeadJobTitles", new[] { "SectionHeadID" });
            DropIndex("dbo.PersonnelJobTitles", new[] { "PersonnelID" });
            AlterColumn("dbo.ProjectTeams", "ProjectTeamDescription", c => c.String(maxLength: 20));
            AlterColumn("dbo.ProjectTeams", "ProjectTeamName", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.SectionHeads", "SectionHeadHireDate");
            DropColumn("dbo.SectionHeads", "SectionHeadRemarks");
            DropColumn("dbo.SectionHeads", "SectionHeadGender");
            DropColumn("dbo.Sections", "SectionDateCreated");
            DropColumn("dbo.Personnels", "PersonnelHireDate");
            DropColumn("dbo.Personnels", "PersonnelRemarks");
            DropColumn("dbo.Personnels", "PersonnelGender");
            DropTable("dbo.SectionHeadJobTitles");
            DropTable("dbo.PersonnelJobTitles");
        }
    }
}
