using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentsClubs.Data;
using StudentsClubs.Models;



namespace StudentsClubs.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex) { }

            //Club c1 = new Club
            //{
            //    ClubID = 1,
            //    ClubName = "ACPC Club",
            //    ClubType = "Programming",
            //    Description = "The ACPC Club aims to encourage students to participate in competitive programming competitions " +
            //     "and develop their programming skills in addition to raising the level of students in the field of Problem Solving.",
            //    LogoURL = ""

            //};
            //Club c2 = new Club
            //{
            //    ClubID = 2,
            //    ClubName = "Photography Club",
            //    ClubType = "Hoppy",
            //    Description = "A Photography Club is a club where people learn about cameras, " +
            //      "improve their photography skills, share their work, and enjoy photography together.",
            //    LogoURL = ""

            //};
            //Club c3 = new Club
            //{
            //    ClubID = 3,
            //    ClubName = "Sport Club",
            //    ClubType = "Sport",
            //    Description = "A Sports Club is a club where people play, learn, and enjoy different sports." +
            //          " It helps members improve their skills, stay active, and make friends.",
            //    LogoURL = ""

            //};
            //Club c4 = new Club
            //{
            //    ClubID = 4,
            //    ClubName = "Culture & Art Club",
            //    ClubType = "Social",
            //    Description = "The Culture & Art Club is a fun club where people learn about different cultures and make art. " +
            //           "It’s a place where you can learn about people from around the world and their traditions. " +
            //           "At the same time, you can draw, paint, and show your artwork and talent. " +
            //           "The club helps people understand each other better and make friends while doing something they love.",
            //    LogoURL = ""

            //};
            //Club c5 = new Club
            //{
            //    ClubID = 5,
            //    ClubName = "Human Development Club",
            //    ClubType = "Education",
            //    Description = "Human Development Club is a club that aim to enhance the personal capabilities,\n" +
            //            " social and professional skills of university students, by organizing interactive events,\n " +
            //            "educational workshops and discussion sessions through which we seek to develop the students’ skills and abilities.",
            //    LogoURL = ""

            //};

            //_db.Clubs.Add(c1);
            //_db.Clubs.Add(c2);
            //_db.Clubs.Add(c3);
            //_db.Clubs.Add(c4);
            //_db.Clubs.Add(c5);
            //_db.SaveChanges();


            //Achievements a1 = new Achievements
            //{
            //    AchievementId = 1,
            //    Title = "Programming Competitions at Arab Open University",
            //    Description = "A Record of Success Organized 9 programming competitions for students of the Arab Open University.",
            //    ClubName = "ACPC Club"

            //};
            //Achievements a2 = new Achievements
            //{
            //    AchievementId = 5,
            //    Title = "Dominance in the Kuwait Collegiate Programming Contest",
            //    Description = "Achieved first place 7 times in the Kuwait Collegiate Programming Contest.",
            //    ClubName = "ACPC Club"

            //};
            //Achievements a3 = new Achievements
            //{
            //    AchievementId = 6,
            //    Title = "Notable Achievement in the 2023 Gulf Programming Competition",
            //    Description = "Achieved fifth place in the Gulf Programming Competition held in Oman in 2023.",
            //    ClubName = "ACPC Club"

            //};
            //Achievements a4 = new Achievements
            //{
            //    AchievementId = 2,
            //    Title = "Key Role in University Events Photography",
            //    Description = "Played a crucial and active role in photographing and covering most of the university's activities and events.",
            //    ClubName = "Photography Club"

            //};
            //Achievements a5 = new Achievements
            //{
            //    AchievementId = 3,
            //    Title = "Football Tournaments for University Students",
            //    Description = "Organized 3 football league tournaments for students of the Arab Open University.",
            //    ClubName = "Sport Club"

            //};
            //Achievements a6 = new Achievements
            //{
            //    AchievementId = 7,
            //    Title = "Bike Race for University Students",
            //    Description = "Organized a cycling race activity for students of the Arab Open University.",
            //    ClubName = "Sport Club"

            //};
            //Achievements a7 = new Achievements
            //{
            //    AchievementId = 4,
            //    Title = "Back-to-Back Success with AOU Got Talent Events",
            //    Description = "Achieved success in organizing the AOU Got Talent activity twice in a row.",
            //    ClubName = "Culture & Art Club"

            //};
            //_db.Achievements.Add(a1);
            //_db.Achievements.Add(a2);
            //_db.Achievements.Add(a3);
            //_db.Achievements.Add(a4);
            //_db.Achievements.Add(a5);
            //_db.Achievements.Add(a6);
            //_db.Achievements.Add(a7);
            //_db.SaveChanges();

            //Membership m1 = new Membership
            //{
            //    Id = 1,
            //    Name = "Raghad Abdallah",
            //    Role = "President",
            //    ClubName = "ACPC Club"

            //};
            //Membership m2 = new Membership
            //{
            //    Id = 2,
            //    Name = "Abdulqader Ramzi",
            //    Role = "Vice-President",
            //    ClubName = "ACPC Club"

            //};
            //Membership m3 = new Membership
            //{
            //    Id = 3,
            //    Name = "Mshari Al-Anezi",
            //    Role = "Cashier",
            //    ClubName = "ACPC Club"

            //};
            //Membership m4 = new Membership
            //{
            //    Id = 4,
            //    Name = "Yasmin Nader",
            //    Role = "Secretary",
            //    ClubName = "ACPC Club"

            //};
            //Membership m5 = new Membership
            //{
            //    Id = 5,
            //    Name = "Mohammad Muhsen",
            //    Role = "President",
            //    ClubName = "Sport Club"

            //};
            //Membership m6 = new Membership
            //{
            //    Id = 6,
            //    Name = "Munir Mohammad",
            //    Role = "Vice-President",
            //    ClubName = "Sport Club"

            //};
            //Membership m7 = new Membership
            //{
            //    Id = 7,
            //    Name = "Awrad Alshammry",
            //    Role = "Cashier",
            //    ClubName = "Sport Club"

            //};
            //Membership m8 = new Membership
            //{
            //    Id = 8,
            //    Name = "Jarah Dawood",
            //    Role = "Secretary",
            //    ClubName = "Sport Club"

            //};
            //Membership m9 = new Membership
            //{
            //    Id = 9,
            //    Name = "Hanan Aljbary",
            //    Role = "President",
            //    ClubName = "Photography Club"

            //};
            //Membership m10 = new Membership
            //{
            //    Id = 10,
            //    Name = "Fahad Al-Anezi",
            //    Role = "Vice-President",
            //    ClubName = "Photography Club"

            //};
            //Membership m11 = new Membership
            //{
            //    Id = 11,
            //    Name = "Rahaf Alotebi",
            //    Role = "Cashier",
            //    ClubName = "Photography Club"

            //};
            //Membership m12 = new Membership
            //{
            //    Id = 12,
            //    Name = "Bandar Alshammry",
            //    Role = "Secretary",
            //    ClubName = "Photography Club"

            //};
            //Membership m13 = new Membership
            //{
            //    Id = 13,
            //    Name = "Sara Alkhulaifi",
            //    Role = "President",
            //    ClubName = "Culture & Art Club"

            //};

            //Membership m14 = new Membership
            //{
            //    Id = 14,
            //    Name = "Bashayer Alghadhban",
            //    Role = "Vice-President",
            //    ClubName = "Culture & Art Club"

            //};
            //Membership m15 = new Membership
            //{
            //    Id = 15,
            //    Name = "Noor Qattan",
            //    Role = "Cashier",
            //    ClubName = "Culture & Art Club"

            //};
            //Membership m16 = new Membership
            //{
            //    Id = 16,
            //    Name = "Rand Khaled",
            //    Role = "Secretary",
            //    ClubName = "Culture & Art Club"

            //};
            //Membership m17 = new Membership
            //{
            //    Id = 17,
            //    Name = "Mahmud Alrefaei",
            //    Role = "President",
            //    ClubName = "Human Development Club"

            //};
            //Membership m18 = new Membership
            //{
            //    Id = 18,
            //    Name = "Ali Albloushi",
            //    Role = "Vice-President",
            //    ClubName = "Human Development Club"

            //};
            //Membership m19 = new Membership
            //{
            //    Id = 19,
            //    Name = "Tala Alfeihan",
            //    Role = "Cashier",
            //    ClubName = "Human Development Club"

            //};
            //Membership m20 = new Membership
            //{
            //    Id = 20,
            //    Name = "Basmala Ammar",
            //    Role = "Secretary",
            //    ClubName = "Human Development Club"

            //};
            //_db.Memberships.Add(m1);
            //_db.Memberships.Add(m2);
            //_db.Memberships.Add(m3);
            //_db.Memberships.Add(m4);
            //_db.Memberships.Add(m5);
            //_db.Memberships.Add(m6);
            //_db.Memberships.Add(m7);
            //_db.Memberships.Add(m8);
            //_db.Memberships.Add(m9);
            //_db.Memberships.Add(m10);
            //_db.Memberships.Add(m11);
            //_db.Memberships.Add(m12);
            //_db.Memberships.Add(m13);
            //_db.Memberships.Add(m14);
            //_db.Memberships.Add(m15);
            //_db.Memberships.Add(m16);
            //_db.Memberships.Add(m17);
            //_db.Memberships.Add(m18);
            //_db.Memberships.Add(m19);
            //_db.Memberships.Add(m20);
            //_db.SaveChanges();


            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Student")).GetAwaiter().GetResult();
                _userManager.CreateAsync(new User
                {
                    UserName = "ragad.alhawali2001@gmail.com",
                    Email = "ragad.alhawali2001@gmail.com",
                    UserFirstName = "Admin",
                    PhoneNumber = "12345",
                    EmailConfirmed = true,
                }, "Admin123*").GetAwaiter().GetResult();
                User user = (User)_db.Users.FirstOrDefault(u => u.Email == "ragad.alhawali2001@gmail.com");
                _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
            }
            return;
        }
    }
}
