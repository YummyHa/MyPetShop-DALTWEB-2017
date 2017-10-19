namespace MyPetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablePetAndCategoryAndPetImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryPets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CategoryId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PetImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uri = c.String(nullable: false),
                        PetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 255),
                        Age = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        CategoryPetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pets");
            DropTable("dbo.PetImages");
            DropTable("dbo.CategoryPets");
            DropTable("dbo.Categories");
        }
    }
}
