namespace MyPetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDescriptionCoulumnInPetsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pets", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "Description", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
