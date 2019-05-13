using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yard_management_system.Models;

namespace yard_management_system.Data
{
    public static class DBInitializer
    {
        public static void Initialize(yard_management_systemContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            const int n = 20;
            var users = new User[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                users[i] = new User
                {
                    UserName = "petras" + i,
                    Password = "*****",
                    EMail = "Petras" + i + "@gmail.com",
                    PhoneNo = rnd.Next(860000000, 869999999).ToString(),
                    FirstName = "Petras" + i,
                    SecondName = "Petrauskas" + i,
                    Blocked = false,
                    UserRight = new UserRight()
                };
            }
           
            foreach (User u in users)
            {
                context.User.Add(u);
            }
 
            context.SaveChanges();
        }
    }
}
