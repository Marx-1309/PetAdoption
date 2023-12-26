using Microsoft.EntityFrameworkCore;
using PetAdoptionMAUI.Api.Data.Entities;
using PetAdoptionMAUI.Shared.Enumerations;

namespace PetAdoptionMAUI.Api.Data;

public class PetContext : DbContext
{
    public PetContext(DbContextOptions<PetContext> options) : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserFavorites> UserFavorites { get; set; }
    public DbSet<UserAdoption> UserAdoptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);


#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine);
#endif
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserFavorites>()
                    .HasKey(uf => new { uf.UserId, uf.PetId });

        modelBuilder.Entity<Pet>()
                    .HasData(InitialPetsData());
    }

    private static List<Pet> InitialPetsData()
    {
        var pets = new List<Pet>
            {
                new Pet
                {
                    Id = 1,
                        Name = "Buddy",
                        Breed = "Dog - Golden Retriever",
                        Price = 300,
                        Description = "Buddy is a friendly and playful Golden Retriever, known for being great with kids and other pets. He enjoys long walks and cuddling on the couch. Buddy is fully vaccinated and ready to bring joy to your family.", Gender = Gender.Male, Image = "img_1.jpg", DateOfBirth = new DateTime(2021, 05, 15)
                },
                new Pet
                {
                    Id = 2, Name = "Whiskers", Breed = "Cat - Siamese", Price = 150, Description = "Whiskers is an elegant Siamese cat who adores attention and loves to cuddle with her humans. She has stunning blue eyes and a soft coat. Whiskers is spayed and ready to be your feline companion.", Gender = Gender.Female, Image = "img_2.jpg", DateOfBirth = new DateTime(2020, 07, 10)
                },
                new Pet
                {
                    Id = 3, Name = "Rocky", Breed = "Dog - German Shepherd", Price = 400, Description = "Rocky is a loyal and protective German Shepherd, ideal for an active family or an individual seeking a faithful companion. He's well-trained and loves outdoor adventures.", Gender = Gender.Male, Image = "img_3.jpg", DateOfBirth = new DateTime(2019, 11, 28)
                },
                new Pet
                {
                    Id = 4, Name = "Luna", Breed = "Rabbit - Himalayan", Price = 50, Description = "Luna is a gentle and low-maintenance Himalayan rabbit, making her a perfect first pet. She enjoys hopping around and nibbling on fresh vegetables. Luna is litter-trained and easy to care for.", Gender = Gender.Female, Image = "img_4.jpg", DateOfBirth = new DateTime(2022, 03, 03)
                },
                new Pet
                {
                    Id = 5, Name = "Simba", Breed = "Guinea Pig - Abyssinian", Price = 25, Description = "Simba is a curious and social Abyssinian guinea pig who thrives on human interaction. He's always excited for playtime and enjoys exploring his surroundings. Simba comes with his own cozy cage and accessories.", Gender = Gender.Male, Image = "img_5.jpg", DateOfBirth = new DateTime(2023, 01, 12)
                },
                new Pet
                {
                    Id = 6, Name = "Lucky", Breed = "Dog - Labrador Retriever", Price = 350, Description = "Lucky is a friendly and energetic Labrador Retriever. He loves playing fetch and going for long hikes. Lucky is up to date on vaccinations and is looking for an active family to join.", Gender = Gender.Male, Image = "img_6.jpg", DateOfBirth = new DateTime(2020, 09, 03)
                },
                new Pet
                {
                    Id = 7, Name = "Daisy", Breed = "Dog - Beagle", Price = 250, Description = "Daisy is a sweet and loving Beagle. She enjoys cuddling on the couch and going for leisurely walks. Daisy is spayed and ready to become your loyal companion.", Gender = Gender.Female, Image = "img_7.jpg", DateOfBirth = new DateTime(2021, 02, 14)
                },
                new Pet
                {
                    Id = 8, Name = "Max", Breed = "Dog - Bulldog", Price = 450, Description = "Max is a gentle and affectionate Bulldog. He's great with children and loves lounging in the sun. Max is microchipped and has a clean bill of health.", Gender = Gender.Male, Image = "img_8.jpg", DateOfBirth = new DateTime(2019, 12, 10)
                },
                new Pet
                {
                    Id = 9, Name = "Sadie", Breed = "Dog - Australian Shepherd", Price = 380, Description = "Sadie is an intelligent and active Australian Shepherd. She excels in obedience training and enjoys agility courses. Sadie is looking for an owner who shares her love for adventure.", Gender = Gender.Female, Image = "img_9.jpg", DateOfBirth = new DateTime(2020, 04, 25)
                },
                new Pet
                {
                    Id = 10, Name = "Rocky", Breed = "Dog - Rottweiler", Price = 300, Description = "Rocky is a strong and protective Rottweiler. He's a loyal companion who takes his role as a guard dog seriously. Rocky is well-trained and ready to keep your home safe.", Gender = Gender.Male, Image = "img_10.jpg", DateOfBirth = new DateTime(2018, 08, 02)
                },
                new Pet
                {
                    Id = 11, Name = "Molly", Breed = "Dog - Dachshund", Price = 200, Description = "Molly is an adorable Dachshund with a playful personality. She enjoys chasing toys and burrowing under blankets. Molly is spayed and ready to add joy to your home.", Gender = Gender.Female, Image = "img_11.jpg", DateOfBirth = new DateTime(2021, 06, 18)
                },
                new Pet
                {
                    Id = 12, Name = "Charlie", Breed = "Dog - Yorkshire Terrier", Price = 280, Description = "Charlie is a lively Yorkshire Terrier full of energy and charm. He's a social pup who loves meeting new people and other dogs. Charlie is fully vaccinated and eager to find a loving family.", Gender = Gender.Male, Image = "img_12.jpg", DateOfBirth = new DateTime(2020, 01, 07)
                },
                new Pet
                {
                    Id = 13, Name = "Bailey", Breed = "Dog - Boxer", Price = 400, Description = "Bailey is an athletic and friendly Boxer. She enjoys playing fetch in the yard and going on long runs. Bailey is looking for an active owner to share her enthusiasm for life.", Gender = Gender.Female, Image = "img_13.jpg", DateOfBirth = new DateTime(2018, 07, 29)
                },
                new Pet
                {
                    Id = 14, Name = "Cooper", Breed = "Dog - Poodle", Price = 320, Description = "Cooper is a smart and well-mannered Poodle. He's hypoallergenic and great for families with allergies. Cooper is crate-trained and ready to be your well-behaved companion.", Gender = Gender.Male, Image = "img_14.jpg", DateOfBirth = new DateTime(2019, 03, 14)
                },
                new Pet
                {
                    Id = 15, Name = "Lucy", Breed = "Dog - Shih Tzu", Price = 280, Description = "Lucy is a sweet and gentle Shih Tzu who adores cuddles and belly rubs. She has a fluffy coat that requires regular grooming. Lucy is spayed and looking for a loving home.", Gender = Gender.Female, Image = "img_15.jpg", DateOfBirth = new DateTime(2022, 08, 09)
                },
                new Pet
                {
                    Id = 16, Name = "Luna", Breed = "Cat - Siamese", Price = 180, Description = "Luna is a graceful Siamese cat with striking blue eyes and a loving personality. She enjoys curling up on the sofa and being pampered. Luna is spayed and ready to bring elegance to your home.", Gender = Gender.Female, Image = "img_16.jpg", DateOfBirth = new DateTime(2022, 02, 12)
                },
                new Pet
                {
                    Id = 17, Name = "Leo", Breed = "Cat - Bengal", Price = 250, Description = "Leo is a playful and adventurous Bengal cat who loves climbing and exploring. He's highly active and enjoys interactive toys. Leo is neutered and looking for a family who shares his sense of adventure.", Gender = Gender.Male, Image = "img_17.jpg", DateOfBirth = new DateTime(2020, 06, 25)
                },
                new Pet
                {
                    Id = 18, Name = "Misty", Breed = "Cat - Ragdoll", Price = 220, Description = "Misty is a gentle and affectionate Ragdoll cat with soft, fluffy fur. She enjoys being cradled like a baby and will purr contentedly in your arms. Misty is spayed and ready to be your loving companion.", Gender = Gender.Female, Image = "img_18.jpg", DateOfBirth = new DateTime(2019, 11, 02)
                },
                new Pet
                {
                    Id = 19, Name = "Oscar", Breed = "Cat - Scottish Fold", Price = 190, Description = "Oscar is an adorable Scottish Fold cat known for his unique folded ears and sweet disposition. He's great with children and enjoys napping in warm spots. Oscar is neutered and seeking a cozy home.", Gender = Gender.Male, Image = "img_19.jpg", DateOfBirth = new DateTime(2021, 03, 17)
                },
                new Pet
                {
                    Id = 20, Name = "Lola", Breed = "Cat - Persian", Price = 270, Description = "Lola is a charming Persian cat with a luxurious long coat and a calm personality. She's used to a life of luxury and enjoys lounging on soft cushions. Lola is spayed and ready for a regal home.", Gender = Gender.Female, Image = "img_20.jpg", DateOfBirth = new DateTime(2020, 08, 07)
                },
                new Pet
                {
                    Id = 21, Name = "Milo", Breed = "Cat - Sphynx", Price = 300, Description = "Milo is a unique Sphynx cat known for his hairless appearance and affectionate nature. He craves warmth and will snuggle under blankets. Milo is neutered and looking for a cozy lap to call his own.", Gender = Gender.Male, Image = "img_21.jpg", DateOfBirth = new DateTime(2020, 01, 29)
                },
                new Pet
                {
                    Id = 22, Name = "Bella", Breed = "Cat - Maine Coon", Price = 240, Description = "Bella is a majestic Maine Coon cat with a lush, flowing coat and a friendly demeanor. She enjoys exploring the great outdoors and is an excellent mouser. Bella is spayed and ready to rule her kingdom.", Gender = Gender.Female, Image = "img_22.jpg", DateOfBirth = new DateTime(2019, 05, 14)
                },
                new Pet
                {
                    Id = 23, Name = "Felix", Breed = "Cat - Russian Blue", Price = 200, Description = "Felix is a sleek and elegant Russian Blue cat with a reserved but affectionate personality. He enjoys quiet moments and observing the world from high perches. Felix is neutered and ready to be your sophisticated companion.", Gender = Gender.Male, Image = "img_23.jpg", DateOfBirth = new DateTime(2021, 07, 22)
                },
                new Pet
                {
                    Id = 24, Name = "Cleo", Breed = "Cat - Egyptian Mau", Price = 230, Description = "Cleo is a stunning Egyptian Mau cat with distinctive spots and a playful spirit. She loves interactive toys and laser pointers. Cleo is spayed and ready to bring a touch of the exotic to your home.", Gender = Gender.Female, Image = "img_24.jpg", DateOfBirth = new DateTime(2020, 03, 11)
                },
                new Pet
                {
                    Id = 25, Name = "Mochi", Breed = "Cat - Scottish Fold", Price = 210, Description = "Mochi is a charming Scottish Fold cat with an endearing folded ear and a sweet temperament. He's great with children and enjoys curling up in cozy spots. Mochi is neutered and ready for cuddles.", Gender = Gender.Male, Image = "img_25.jpg", DateOfBirth = new DateTime(2019, 09, 30)
                },
                new Pet
                {
                    Id = 26, Name = "Raja", Breed = "Dog - Indian Pariah", Price = 100, Description = "Raja is a friendly Indian Pariah dog, known for his loyalty and adaptability. He's great with kids and enjoys long walks. Raja is looking for a loving family to call his own.", Gender = Gender.Male, Image = "img_26.jpg", DateOfBirth = new DateTime(2019, 08, 15)
                },
                new Pet
                {
                    Id = 27, Name = "Chandni", Breed = "Cat - Indian Shorthair", Price = 80, Description = "Chandni is a graceful Indian Shorthair cat with a silky coat and a calm demeanor. She enjoys lounging in the sun and being pampered. Chandni is spayed and ready to grace your home.", Gender = Gender.Female, Image = "img_27.jpg", DateOfBirth = new DateTime(2020, 01, 22)
                },
                new Pet
                {
                    Id = 28, Name = "Sheru", Breed = "Dog - Rajapalayam", Price = 200, Description = "Sheru is a majestic Rajapalayam dog with a strong and noble presence. He's an excellent guard dog and is fiercely loyal to his family. Sheru is ready to protect and serve.", Gender = Gender.Male, Image = "img_28.jpg", DateOfBirth = new DateTime(2018, 12, 10)
                },
                new Pet
                {
                    Id = 29, Name = "Meera", Breed = "Cat - Indian Siamese", Price = 70, Description = "Meera is a charming Indian Siamese cat with striking blue eyes and a playful personality. She enjoys interactive toys and cuddling with her humans. Meera is looking for a loving home.", Gender = Gender.Female, Image = "img_29.jpg", DateOfBirth = new DateTime(2019, 06, 18)
                },
                new Pet
                {
                    Id = 30, Name = "Krishna", Breed = "Dog - Mudhol Hound", Price = 150, Description = "Krishna is a swift and agile Mudhol Hound, known for his hunting prowess and friendly disposition. He loves outdoor adventures and is looking for an active family.", Gender = Gender.Male, Image = "img_30.jpg", DateOfBirth = new DateTime(2019, 05, 05)
                },
                new Pet
                {
                    Id = 31, Name = "Amara", Breed = "Cat - Indian Persian", Price = 90, Description = "Amara is an elegant Indian Persian cat with a luxurious long coat and a calm personality. She enjoys being pampered and lounging in comfort. Amara is spayed and ready for a regal home.", Gender = Gender.Female, Image = "img_11.jpg", DateOfBirth = new DateTime(2019, 09, 12)
                },
                new Pet
                {
                    Id = 32, Name = "Kumar", Breed = "Dog - Kombai", Price = 180, Description = "Kumar is a brave and loyal Kombai dog, known for his protective instincts and affectionate nature. He's great with children and is looking for a loving family to guard.", Gender = Gender.Male, Image = "img_22.jpg", DateOfBirth = new DateTime(2022, 02, 10)
                },
                new Pet
                {
                    Id = 33, Name = "Sakshi", Breed = "Cat - Indian Bobtail", Price = 75, Description = "Sakshi is an inquisitive Indian Bobtail cat with a distinctive bobbed tail and a playful spirit. She enjoys chasing toys and exploring her surroundings. Sakshi is spayed and ready to brighten your home.", Gender = Gender.Female, Image = "img_3.jpg", DateOfBirth = new DateTime(2020, 03, 19)
                },
                new Pet
                {
                    Id = 34, Name = "Arya", Breed = "Dog - Himalayan Sheepdog", Price = 220, Description = "Arya is a courageous Himalayan Sheepdog, known for her endurance and protective instincts. She's an excellent choice for rural living and is looking for a responsible owner.", Gender = Gender.Female, Image = "img_14.jpg", DateOfBirth = new DateTime(2018, 11, 25)
                },
                new Pet
                {
                    Id = 35, Name = "Rani", Breed = "Cat - Indian Mau", Price = 85, Description = "Rani is a graceful Indian Mau cat with distinctive spots and a playful spirit. She enjoys interactive toys and sunbathing by the window. Rani is spayed and ready to bring joy to your home.", Gender = Gender.Female, Image = "img_25.jpg", DateOfBirth = new DateTime(2020, 07, 14)
                }
            };
        return pets;
    }
}
