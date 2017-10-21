namespace MyPetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCategoryIdInCategoryPetsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CategoryPets", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CategoryPets", "CategoryId", c => c.String(nullable: false));
        }
    }
}
