using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yard_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace yard_management_system.Data
{
    public static class DBInitializer
    {
        const int n = 20;

        public static void Initialize(yard_management_systemContext context)
        {
            context.Database.EnsureCreated();

            InitializeUsers(context);
            InitializeRamps(context);
            InitializeTimeSlots(context);
            InitializeEntries(context);
            InitializeContractors(context);
        }

        public static void InitializeUsers(yard_management_systemContext context)
        {
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                users[i] = new User
                {
                    UserID = i,
                    UserName = "petras" + i,
                    Password = "*****",
                    EMail = "Petras" + i + "@gmail.com",
                    PhoneNo = rnd.Next(860000000, 869999999).ToString(),
                    FirstName = "Petras" + i,
                    SecondName = "Petrauskas" + i,
                    Blocked = false
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

            var ramps = new Ramp[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                DateTime date = RandomDay(rnd);
                ramps[i] = new Ramp
                {
                    ID = i,
                    Code = rnd.Next(00000, 99999).ToString(),
                    CategoryOfRamp = Ramp.Category.C,
                    Blocked = false,
                    CreationDate = DateTime.Now,
                    UserCreatorID = i
                };
            }

            foreach (Ramp r in ramps)
            {
                context.Ramp.Add(r);
            }

            context.SaveChanges();
        }

        public static void InitializeTimeSlots(yard_management_systemContext context)
        {
            if (context.TimeSlot.Any())
            {
                return;   // DB has been seeded
            }

            var timeSlots = new TimeSlot[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                timeSlots[i] = new TimeSlot
                {
                    TimeSlotID = i,
                    Date = GetFutureDate(rnd, DateTime.Now),
                    TimeFrom = "13:00",
                    TimeDuration = "60",
                    TypeOfTimeSlot = TimeSlot.TimeSlotType.aktyvus,
                    Reserved = false,
                    Blocked = false,
                    RampID = i
                };
            }

            foreach (TimeSlot t in timeSlots)
            {
                context.TimeSlot.Add(t);
            }

            context.SaveChanges();
        }

        public static void InitializeEntries(yard_management_systemContext context)
        {
            if (context.Entry.Any())
            {
                return;   // DB has been seeded
            }

            const int n = 20;
            var entries = new Entry[n];
            Random rnd = new Random();
            int lastIndex = context.ObjectChanges.Max(p => p.ID);

            for (int i = 0; i < n; i++)
            {
                DateTime date = RandomDay(rnd);
                entries[i] = new Entry
                {
                    ID = lastIndex + i + 1,
                    Code = rnd.Next(00000, 99999).ToString(),
                    Blocked = false,
                    CreationDate = DateTime.Now,
                    UserCreatorID = i
                };
            }

            foreach (Entry e in entries)
            {
                context.Entry.Add(e);
            }

            context.SaveChanges();
        }

        public static void InitializeContractors(yard_management_systemContext context)
        {
            if (context.Contractor.Any())
            {
                return;   // DB has been seeded
            }

            var contractors = new Contractor[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                contractors[i] = new Contractor
                {
                    TypeOfContractor = Contractor.ContractorType.Vairuotojas,
                    UserID = i
                };
            }

            foreach (Contractor c in contractors)
            {
                context.Contractor.Add(c);
            }

            context.SaveChanges();
        }

        public static DateTime GetFutureDate(Random gen, DateTime oldDate)
        {
            DateTime newDate = RandomDay(gen);
            while (newDate <= oldDate)
            {
                newDate = RandomDay(gen);
            }
            return newDate;
        }

        public static DateTime RandomDay(Random gen)
        {
            DateTime start = new DateTime(2016, 1, 1);
            return start.AddDays(gen.Next(3000));
        }
    }
}
