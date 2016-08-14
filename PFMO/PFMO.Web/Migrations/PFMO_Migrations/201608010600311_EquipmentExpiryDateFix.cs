namespace PFMO.Web.Migrations.PFMO_Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EquipmentExpiryDateFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "EquipmentExpiryDate", c => c.DateTime(nullable: false));
            //DropColumn("dbo.Equipments", "SupplyExpiryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipments", "SupplyExpiryDate", c => c.DateTime(nullable: false));
            //DropColumn("dbo.Equipments", "EquipmentExpiryDate");
        }
    }
}
