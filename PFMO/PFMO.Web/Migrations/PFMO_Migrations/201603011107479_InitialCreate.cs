namespace PFMO.Web.Migrations.PFMO_Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Guid(nullable: false),
                        ContactName = c.String(maxLength: 17),
                        ContactDescription = c.String(maxLength: 20),
                        ContactType = c.String(maxLength: 16),
                        ContactOffice = c.String(maxLength: 16),
                        ContactEmail = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
