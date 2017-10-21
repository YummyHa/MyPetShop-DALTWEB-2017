namespace MyPetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES (NAME) VALUES ('Dog')");

            Sql("INSERT INTO CATEGORIES (NAME) VALUES ('Cat')");
        }
        
        public override void Down()
        {
        }
    }
}
