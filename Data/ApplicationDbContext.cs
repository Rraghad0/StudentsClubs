using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsClubs.Models;
using System.Diagnostics;
using System.Drawing;


namespace StudentsClubs.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Achievements> Achievements { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Volunteers> Volunteers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Club>().HasData(
                new Club
                {
                    ClubID = 1,
                    ClubName = "ACPC Club",
                    ClubType = "Programming",
                    Description = "The ACPC Club aims to encourage students to participate in competitive programming competitions " +
                    "and develop their programming skills in addition to raising the level of students in the field of Problem Solving.",
                    LogoURL = "/images/club/e4d4c651-c964-4d61-99ca-ba20a552788c.png",
                    WhatsAppGroupLink = "https://chat.whatsapp.com/IVAdaPHWlWn7qEmXfYNLJS"

                },
                 new Club
                 {
                     ClubID = 2,
                     ClubName = "Photography Club",
                     ClubType = "Hoppy",
                     Description = "A Photography Club is a club where people learn about cameras, " +
                     "improve their photography skills, share their work, and enjoy photography together.",
                     LogoURL = "/images/club/e0afa475-7340-4e2e-b4ba-e1f79531586a.jpg",
                     WhatsAppGroupLink = "https://chat.whatsapp.com/IVAdaPHWlWn7qEmXfYNLJS"

                 },
                  new Club
                  {
                      ClubID = 3,
                      ClubName = "Sport Club",
                      ClubType = "Sport",
                      Description = "A Sports Club is a club where people play, learn, and enjoy different sports." +
                      " It helps members improve their skills, stay active, and make friends.",
                      LogoURL = "/images/club/cee9c14d-0522-4d64-bf5d-9634ab011ed3.jpg",
                      WhatsAppGroupLink = "https://chat.whatsapp.com/IVAdaPHWlWn7qEmXfYNLJS"

                  },
                   new Club
                   {
                       ClubID = 4,
                       ClubName = "Culture & Art Club",
                       ClubType = "Social",
                       Description = "The Culture & Art Club is a fun club where people learn about different cultures and make art. " +
                       "It’s a place where you can learn about people from around the world and their traditions. " +
                       "At the same time, you can draw, paint, and show your artwork and talent. " +
                       "The club helps people understand each other better and make friends while doing something they love.",
                       LogoURL = "/images/club/8421c316-da19-4d91-86a0-c98b93cc57ca.jpg",
                       WhatsAppGroupLink = "https://chat.whatsapp.com/IVAdaPHWlWn7qEmXfYNLJS"

                   },
                    new Club
                    {
                        ClubID = 5,
                        ClubName = "Human Development Club",
                        ClubType = "Education",
                        Description = "Human Development Club is a club that aim to enhance the personal capabilities,\n" +
                        " social and professional skills of university students, by organizing interactive events,\n " +
                        "educational workshops and discussion sessions through which we seek to develop the students’ skills and abilities.",
                        LogoURL = "/images/club/9d2f3c9f-e104-4ae6-b74e-b26be00548b6.jpg",
                        WhatsAppGroupLink = "https://chat.whatsapp.com/IVAdaPHWlWn7qEmXfYNLJS"

                    }
                );
            modelBuilder.Entity<Achievements>().HasData(
                new Achievements
                {
                    AchievementId = 1,
                    Title = "Programming Competitions at Arab Open University",
                    Description = "A Record of Success Organized 9 programming competitions for students of the Arab Open University.",
                    ClubName = "ACPC Club"

                },
                  new Achievements
                  {
                      AchievementId = 5,
                      Title = "Dominance in the Kuwait Collegiate Programming Contest",
                      Description = "Achieved first place 7 times in the Kuwait Collegiate Programming Contest.",
                      ClubName = "ACPC Club"

                  },
                    new Achievements
                    {
                        AchievementId = 6,
                        Title = "Notable Achievement in the 2023 Gulf Programming Competition",
                        Description = "Achieved fifth place in the Gulf Programming Competition held in Oman in 2023.",
                        ClubName = "ACPC Club"

                    },
                new Achievements
                {
                    AchievementId = 2,
                    Title = "Key Role in University Events Photography",
                    Description = "Played a crucial and active role in photographing and covering most of the university's activities and events.",
                    ClubName = "Photography Club"

                },
                new Achievements
                {
                    AchievementId = 3,
                    Title = "Football Tournaments for University Students",
                    Description = "Organized 3 football league tournaments for students of the Arab Open University.",
                    ClubName = "Sport Club"

                },
                 new Achievements
                 {
                     AchievementId = 7,
                     Title = "Bike Race for University Students",
                     Description = "Organized a cycling race activity for students of the Arab Open University.",
                     ClubName = "Sport Club"

                 },
                new Achievements
                {
                    AchievementId = 4,
                    Title = "Back-to-Back Success with AOU Got Talent Events",
                    Description = "Achieved success in organizing the AOU Got Talent activity twice in a row.",
                    ClubName = "Culture & Art Club"

                }

            );
            modelBuilder.Entity<Membership>().HasData(
               new Membership
               {
                   Id = 1,
                   Name = "Raghad Abdallah",
                   Role = "President",
                   ClubName = "ACPC Club"

               },
                new Membership
                {
                    Id = 2,
                    Name = "Abdulqader Ramzi",
                    Role = "Vice-President",
                    ClubName = "ACPC Club"

                },
                 new Membership
                 {
                     Id = 3,
                     Name = "Mshari Al-Anezi",
                     Role = "Cashier",
                     ClubName = "ACPC Club"

                 },
                  new Membership
                  {
                      Id = 4,
                      Name = "Yasmin Nader",
                      Role = "Secretary",
                      ClubName = "ACPC Club"

                  },
                   new Membership
                   {
                       Id = 5,
                       Name = "Mohammad Muhsen",
                       Role = "President",
                       ClubName = "Sport Club"

                   },
                  new Membership
                  {
                      Id = 6,
                      Name = "Munir Mohammad",
                      Role = "Vice-President",
                      ClubName = "Sport Club"

                  },
                   new Membership
                   {
                       Id = 7,
                       Name = "Awrad Alshammry",
                       Role = "Cashier",
                       ClubName = "Sport Club"

                   },
                    new Membership
                    {
                        Id = 8,
                        Name = "Jarah Dawood",
                        Role = "Secretary",
                        ClubName = "Sport Club"

                    },
                     new Membership
                     {
                         Id = 9,
                         Name = "Hanan Aljbary",
                         Role = "President",
                         ClubName = "Photography Club"

                     },
                  new Membership
                  {
                      Id = 10,
                      Name = "Fahad Al-Anezi",
                      Role = "Vice-President",
                      ClubName = "Photography Club"

                  },
                   new Membership
                   {
                       Id = 11,
                       Name = "Rahaf Alotebi",
                       Role = "Cashier",
                       ClubName = "Photography Club"

                   },
                    new Membership
                    {
                        Id = 12,
                        Name = "Bandar Alshammry",
                        Role = "Secretary",
                        ClubName = "Photography Club"

                    },
                     new Membership
                     {
                         Id = 13,
                         Name = "Sara Alkhulaifi",
                         Role = "President",
                         ClubName = "Culture & Art Club"

                     },

                      new Membership
                      {
                          Id = 14,
                          Name = "Bashayer Alghadhban",
                          Role = "Vice-President",
                          ClubName = "Culture & Art Club"

                      },
                       new Membership
                       {
                           Id = 15,
                           Name = "Noor Qattan",
                           Role = "Cashier",
                           ClubName = "Culture & Art Club"

                       },
                        new Membership
                        {
                            Id = 16,
                            Name = "Rand Khaled",
                            Role = "Secretary",
                            ClubName = "Culture & Art Club"

                        },
                         new Membership
                         {
                             Id = 17,
                             Name = "Mahmud Alrefaei",
                             Role = "President",
                             ClubName = "Human Development Club"

                         },
                      new Membership
                      {
                          Id = 18,
                          Name = "Ali Albloushi",
                          Role = "Vice-President",
                          ClubName = "Human Development Club"

                      },
                       new Membership
                       {
                           Id = 19,
                           Name = "Tala Alfeihan",
                           Role = "Cashier",
                           ClubName = "Human Development Club"

                       },
                        new Membership
                        {
                            Id = 20,
                            Name = "Basmala Ammar",
                            Role = "Secretary",
                            ClubName = "Human Development Club"

                        }
                 );

        }

    }
}

