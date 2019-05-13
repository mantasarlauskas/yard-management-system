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

            InitializeUsers(context);
            InitializeRamps(context);
        }

        public static void InitializeUsers(yard_management_systemContext context)
        {
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

        public static void InitializeRamps(yard_management_systemContext context)
        {
            if (context.Ramp.Any())
            {
                return;   // DB has been seeded
            }

            const int n = 20;
            var ramps = new Ramp[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                ramps[i] = new Ramp
                {
                    Code = rnd.Next(00000, 99999).ToString(),
                    CategoryOfRamp = Ramp.Category.C,
                    Blocked = i % 2 == 0 ? false : true,
                    BlockedFrom = RandomDay(rnd),
                    BlockedTo = RandomDay(rnd),
                    CreationDate = new DateTime(),
                    UserCreatorId = 1
                };
            }

            foreach (Ramp r in ramps)
            {
                context.Ramp.Add(r);
            }

            context.SaveChanges();
        }

        
        public static DateTime RandomDay(Random gen)
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
