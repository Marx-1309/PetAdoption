using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetAdoptionMAUI.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    AdoptionStatus = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAdoptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    AdoptedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdoptions_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdoptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => new { x.UserId, x.PetId });
                    table.ForeignKey(
                        name: "FK_UserFavorites_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionStatus", "Breed", "DateOfBirth", "Description", "Gender", "Image", "IsActive", "Name", "Price", "Views" },
                values: new object[,]
                {
                    { 1, 1, "Dog - Golden Retriever", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buddy is a friendly and playful Golden Retriever, known for being great with kids and other pets. He enjoys long walks and cuddling on the couch. Buddy is fully vaccinated and ready to bring joy to your family.", 0, "img_1.jpg", true, "Buddy", 300.0, 0 },
                    { 2, 1, "Cat - Siamese", new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whiskers is an elegant Siamese cat who adores attention and loves to cuddle with her humans. She has stunning blue eyes and a soft coat. Whiskers is spayed and ready to be your feline companion.", 1, "img_2.jpg", true, "Whiskers", 150.0, 0 },
                    { 3, 1, "Dog - German Shepherd", new DateTime(2019, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocky is a loyal and protective German Shepherd, ideal for an active family or an individual seeking a faithful companion. He's well-trained and loves outdoor adventures.", 0, "img_3.jpg", true, "Rocky", 400.0, 0 },
                    { 4, 1, "Rabbit - Himalayan", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luna is a gentle and low-maintenance Himalayan rabbit, making her a perfect first pet. She enjoys hopping around and nibbling on fresh vegetables. Luna is litter-trained and easy to care for.", 1, "img_4.jpg", true, "Luna", 50.0, 0 },
                    { 5, 1, "Guinea Pig - Abyssinian", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simba is a curious and social Abyssinian guinea pig who thrives on human interaction. He's always excited for playtime and enjoys exploring his surroundings. Simba comes with his own cozy cage and accessories.", 0, "img_5.jpg", true, "Simba", 25.0, 0 },
                    { 6, 1, "Dog - Labrador Retriever", new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucky is a friendly and energetic Labrador Retriever. He loves playing fetch and going for long hikes. Lucky is up to date on vaccinations and is looking for an active family to join.", 0, "img_6.jpg", true, "Lucky", 350.0, 0 },
                    { 7, 1, "Dog - Beagle", new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daisy is a sweet and loving Beagle. She enjoys cuddling on the couch and going for leisurely walks. Daisy is spayed and ready to become your loyal companion.", 1, "img_7.jpg", true, "Daisy", 250.0, 0 },
                    { 8, 1, "Dog - Bulldog", new DateTime(2019, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max is a gentle and affectionate Bulldog. He's great with children and loves lounging in the sun. Max is microchipped and has a clean bill of health.", 0, "img_8.jpg", true, "Max", 450.0, 0 },
                    { 9, 1, "Dog - Australian Shepherd", new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sadie is an intelligent and active Australian Shepherd. She excels in obedience training and enjoys agility courses. Sadie is looking for an owner who shares her love for adventure.", 1, "img_9.jpg", true, "Sadie", 380.0, 0 },
                    { 10, 1, "Dog - Rottweiler", new DateTime(2018, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocky is a strong and protective Rottweiler. He's a loyal companion who takes his role as a guard dog seriously. Rocky is well-trained and ready to keep your home safe.", 0, "img_10.jpg", true, "Rocky", 300.0, 0 },
                    { 11, 1, "Dog - Dachshund", new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Molly is an adorable Dachshund with a playful personality. She enjoys chasing toys and burrowing under blankets. Molly is spayed and ready to add joy to your home.", 1, "img_11.jpg", true, "Molly", 200.0, 0 },
                    { 12, 1, "Dog - Yorkshire Terrier", new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie is a lively Yorkshire Terrier full of energy and charm. He's a social pup who loves meeting new people and other dogs. Charlie is fully vaccinated and eager to find a loving family.", 0, "img_12.jpg", true, "Charlie", 280.0, 0 },
                    { 13, 1, "Dog - Boxer", new DateTime(2018, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bailey is an athletic and friendly Boxer. She enjoys playing fetch in the yard and going on long runs. Bailey is looking for an active owner to share her enthusiasm for life.", 1, "img_13.jpg", true, "Bailey", 400.0, 0 },
                    { 14, 1, "Dog - Poodle", new DateTime(2019, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cooper is a smart and well-mannered Poodle. He's hypoallergenic and great for families with allergies. Cooper is crate-trained and ready to be your well-behaved companion.", 0, "img_14.jpg", true, "Cooper", 320.0, 0 },
                    { 15, 1, "Dog - Shih Tzu", new DateTime(2022, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucy is a sweet and gentle Shih Tzu who adores cuddles and belly rubs. She has a fluffy coat that requires regular grooming. Lucy is spayed and looking for a loving home.", 1, "img_15.jpg", true, "Lucy", 280.0, 0 },
                    { 16, 1, "Cat - Siamese", new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luna is a graceful Siamese cat with striking blue eyes and a loving personality. She enjoys curling up on the sofa and being pampered. Luna is spayed and ready to bring elegance to your home.", 1, "img_16.jpg", true, "Luna", 180.0, 0 },
                    { 17, 1, "Cat - Bengal", new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leo is a playful and adventurous Bengal cat who loves climbing and exploring. He's highly active and enjoys interactive toys. Leo is neutered and looking for a family who shares his sense of adventure.", 0, "img_17.jpg", true, "Leo", 250.0, 0 },
                    { 18, 1, "Cat - Ragdoll", new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Misty is a gentle and affectionate Ragdoll cat with soft, fluffy fur. She enjoys being cradled like a baby and will purr contentedly in your arms. Misty is spayed and ready to be your loving companion.", 1, "img_18.jpg", true, "Misty", 220.0, 0 },
                    { 19, 1, "Cat - Scottish Fold", new DateTime(2021, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oscar is an adorable Scottish Fold cat known for his unique folded ears and sweet disposition. He's great with children and enjoys napping in warm spots. Oscar is neutered and seeking a cozy home.", 0, "img_19.jpg", true, "Oscar", 190.0, 0 },
                    { 20, 1, "Cat - Persian", new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lola is a charming Persian cat with a luxurious long coat and a calm personality. She's used to a life of luxury and enjoys lounging on soft cushions. Lola is spayed and ready for a regal home.", 1, "img_20.jpg", true, "Lola", 270.0, 0 },
                    { 21, 1, "Cat - Sphynx", new DateTime(2020, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milo is a unique Sphynx cat known for his hairless appearance and affectionate nature. He craves warmth and will snuggle under blankets. Milo is neutered and looking for a cozy lap to call his own.", 0, "img_21.jpg", true, "Milo", 300.0, 0 },
                    { 22, 1, "Cat - Maine Coon", new DateTime(2019, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bella is a majestic Maine Coon cat with a lush, flowing coat and a friendly demeanor. She enjoys exploring the great outdoors and is an excellent mouser. Bella is spayed and ready to rule her kingdom.", 1, "img_22.jpg", true, "Bella", 240.0, 0 },
                    { 23, 1, "Cat - Russian Blue", new DateTime(2021, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Felix is a sleek and elegant Russian Blue cat with a reserved but affectionate personality. He enjoys quiet moments and observing the world from high perches. Felix is neutered and ready to be your sophisticated companion.", 0, "img_23.jpg", true, "Felix", 200.0, 0 },
                    { 24, 1, "Cat - Egyptian Mau", new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cleo is a stunning Egyptian Mau cat with distinctive spots and a playful spirit. She loves interactive toys and laser pointers. Cleo is spayed and ready to bring a touch of the exotic to your home.", 1, "img_24.jpg", true, "Cleo", 230.0, 0 },
                    { 25, 1, "Cat - Scottish Fold", new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mochi is a charming Scottish Fold cat with an endearing folded ear and a sweet temperament. He's great with children and enjoys curling up in cozy spots. Mochi is neutered and ready for cuddles.", 0, "img_25.jpg", true, "Mochi", 210.0, 0 },
                    { 26, 1, "Dog - Indian Pariah", new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raja is a friendly Indian Pariah dog, known for his loyalty and adaptability. He's great with kids and enjoys long walks. Raja is looking for a loving family to call his own.", 0, "img_26.jpg", true, "Raja", 100.0, 0 },
                    { 27, 1, "Cat - Indian Shorthair", new DateTime(2020, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chandni is a graceful Indian Shorthair cat with a silky coat and a calm demeanor. She enjoys lounging in the sun and being pampered. Chandni is spayed and ready to grace your home.", 1, "img_27.jpg", true, "Chandni", 80.0, 0 },
                    { 28, 1, "Dog - Rajapalayam", new DateTime(2018, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sheru is a majestic Rajapalayam dog with a strong and noble presence. He's an excellent guard dog and is fiercely loyal to his family. Sheru is ready to protect and serve.", 0, "img_28.jpg", true, "Sheru", 200.0, 0 },
                    { 29, 1, "Cat - Indian Siamese", new DateTime(2019, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meera is a charming Indian Siamese cat with striking blue eyes and a playful personality. She enjoys interactive toys and cuddling with her humans. Meera is looking for a loving home.", 1, "img_29.jpg", true, "Meera", 70.0, 0 },
                    { 30, 1, "Dog - Mudhol Hound", new DateTime(2019, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krishna is a swift and agile Mudhol Hound, known for his hunting prowess and friendly disposition. He loves outdoor adventures and is looking for an active family.", 0, "img_30.jpg", true, "Krishna", 150.0, 0 },
                    { 31, 1, "Cat - Indian Persian", new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amara is an elegant Indian Persian cat with a luxurious long coat and a calm personality. She enjoys being pampered and lounging in comfort. Amara is spayed and ready for a regal home.", 1, "img_11.jpg", true, "Amara", 90.0, 0 },
                    { 32, 1, "Dog - Kombai", new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar is a brave and loyal Kombai dog, known for his protective instincts and affectionate nature. He's great with children and is looking for a loving family to guard.", 0, "img_22.jpg", true, "Kumar", 180.0, 0 },
                    { 33, 1, "Cat - Indian Bobtail", new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sakshi is an inquisitive Indian Bobtail cat with a distinctive bobbed tail and a playful spirit. She enjoys chasing toys and exploring her surroundings. Sakshi is spayed and ready to brighten your home.", 1, "img_3.jpg", true, "Sakshi", 75.0, 0 },
                    { 34, 1, "Dog - Himalayan Sheepdog", new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arya is a courageous Himalayan Sheepdog, known for her endurance and protective instincts. She's an excellent choice for rural living and is looking for a responsible owner.", 1, "img_14.jpg", true, "Arya", 220.0, 0 },
                    { 35, 1, "Cat - Indian Mau", new DateTime(2020, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rani is a graceful Indian Mau cat with distinctive spots and a playful spirit. She enjoys interactive toys and sunbathing by the window. Rani is spayed and ready to bring joy to your home.", 1, "img_25.jpg", true, "Rani", 85.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAdoptions_PetId",
                table: "UserAdoptions",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdoptions_UserId",
                table: "UserAdoptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_PetId",
                table: "UserFavorites",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAdoptions");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
