namespace MyPetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePetsTableAgain : DbMigration
    {
        public override void Up()
        {
            // Add Some Dogs
            Sql("INSERT INTO PETS (NAME, Description, Age, Price, Status, CategoryPetId) VALUES ('Corgi 1', 'It is one of two breeds known as a Welsh Corgi. The other is the Cardigan Welsh Corgi, and both descend from the line that is the northern spitz-type dog (examples include that of the Siberian Husky).', 3, 2000, 0, 1)");
            Sql("INSERT INTO PetImages (Uri, PetId) VALUES ('/Images/corgi_1.png', 1)");

            Sql("INSERT INTO PETS (NAME, Description, Age, Price, Status, CategoryPetId) VALUES ('Husky 1', 'They are an ever-changing cross-breed of the fastest dogs. The Alaskan Malamute, by contrast, is the largest and most powerful sled dog, and was used for heavier loads.', 2, 1200, 0, 3)");
            Sql("INSERT INTO PetImages (Uri, PetId) VALUES ('/Images/husky_1.png', 2)");

            Sql("INSERT INTO PETS (NAME, Description, Age, Price, Status, CategoryPetId) VALUES ('Samoyed 1', 'It takes its name from the Samoyedic peoples of Siberia. These nomadic reindeer herders bred the fluffy white dogs to help with the herding, and to pull sleds when they moved.', 2.5, 2200, 0, 10)");
            Sql("INSERT INTO PetImages (Uri, PetId) VALUES ('/Images/samoyed_1.png', 3)");

            Sql("INSERT INTO PETS (NAME, Description, Age, Price, Status, CategoryPetId) VALUES ('Pug 1', 'The breed has a fine, glossy coat that comes in a variety of colours, most often fawn or black, and a compact square body with well-developed muscles.', 1.5, 500, 0, 2)");
            Sql("INSERT INTO PetImages (Uri, PetId) VALUES ('/Images/pug_1.png', 4)");

            Sql("INSERT INTO PETS (NAME, Description, Age, Price, Status, CategoryPetId) VALUES ('Poodle 1', 'The poodle is a group of formal dog breeds, the Standard Poodle, Miniature Poodle and Toy Poodle. The origins of the poodles are still discussed with a dispute over .', 2, 550, 0, 6)");
            Sql("INSERT INTO PetImages (Uri, PetId) VALUES ('/Images/poodle_1.png', 5)");

            // Add Some Cats
            Sql("INSERT INTO PETS (NAME, Description, Age, Price, Status, CategoryPetId) VALUES ('British ShortHair 1', 'The British Shorthair is the pedigreed version of the traditional British domestic cat, with a distinctively chunky body, dense coat and broad face. The most familiar color variant is the British Blue.', 1, 900, 0, 11)");
            Sql("INSERT INTO PetImages (Uri, PetId) VALUES ('/Images/british_shorthair_1.png', 6)");

            Sql("INSERT INTO PETS (NAME, Description, Age, Price, Status, CategoryPetId) VALUES ('RagDoll 1', 'The Ragdoll is a cat breed with blue eyes and a distinct colourpoint coat. It is a large and muscular semi-longhair cat with a soft and silky coat. Like all long haired cats, Ragdolls need grooming to ensure their fur does not mat.', 1.5, 800, 0, 12)");
            Sql("INSERT INTO PetImages (Uri, PetId) VALUES ('/Images/ragdoll_1.png', 7)");

            Sql("INSERT INTO PETS (NAME, Description, Age, Price, Status, CategoryPetId) VALUES ('Manie Coon 1', 'The Maine Coon is one of the largest domesticated breeds of cat. It has a distinctive physical appearance and valuable hunting skills. It is one of the oldest natural breeds in North America, specifically native to the state of Maine.', 3.5, 700, 0, 13)");
            Sql("INSERT INTO PetImages (Uri, PetId) VALUES ('/Images/manie_coon_1.png', 8)");

            Sql("INSERT INTO PETS (NAME, Description, Age, Price, Status, CategoryPetId) VALUES ('Exotic Shorthair 1', 'The Exotic Shorthair is a breed of cat developed to be a short-haired version of the Persian. The Exotic is similar to the Persian in many ways, including temperament and conformation.', 2.5, 1500, 0, 14)");
            Sql("INSERT INTO PetImages (Uri, PetId) VALUES ('/Images/exotic_shorthair_1.png', 9)");

            Sql("INSERT INTO PETS (NAME, Description, Age, Price, Status, CategoryPetId) VALUES ('Persian 1', 'The Persian cat is a long-haired breed of cat characterized by its round face and short muzzle. It is also known as the Persian Longhair.', 3, 950, 0, 15)");
            Sql("INSERT INTO PetImages (Uri, PetId) VALUES ('/Images/persian_1.png', 10)");
        }
        
        public override void Down()
        {
        }
    }
}
