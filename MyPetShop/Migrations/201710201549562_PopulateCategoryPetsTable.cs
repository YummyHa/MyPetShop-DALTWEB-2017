namespace MyPetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryPetsTable : DbMigration
    {
        public override void Up()
        {
            // Add category for Dogs
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Corgi', 1)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Pug', 1)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Husky', 1)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Alaska', 1)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Hachiko', 1)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Poodle', 1)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Bulldog', 1)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Golden Retriever', 1)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Labrador Retriever', 1)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Samoyed', 1)");

            // Add category for Cats
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('British Shorthair', 2)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Ragdoll', 2)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Maine Coon', 2)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Exotic Shorthair', 2)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Persian', 2)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('American Shorthair', 2)");
            Sql("INSERT INTO CATEGORYPETS (NAME, CategoryId) VALUES ('Scottish Fold', 2)");
        }
        
        public override void Down()
        {
        }
    }
}
