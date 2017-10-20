namespace MyPetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES (NAME) VALUES ('Cho')");

            Sql("INSERT INTO CATEGORIES (NAME) VALUES ('Meo')");
        }
        
        public override void Down()
        {
        }
    }
}
