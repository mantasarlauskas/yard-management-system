using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yard_management_system.Models;

namespace yard_management_system.Models
{
    public class yard_management_systemContext : DbContext
    {
        public yard_management_systemContext (DbContextOptions<yard_management_systemContext> options)
            : base(options)
        {
        }

        public DbSet<ObjectChange> ObjectChanges { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Message> Message { get; set; }

        public DbSet<Permission> Permission { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Cargo> Cargo { get; set; }

        public DbSet<CargoTimeSlot> CargoTimeSlot { get; set; }

        public DbSet<Ramp> Ramp { get; set; }

        public DbSet<TimeSlot> TimeSlot { get; set; }

        public DbSet<Entry> Entry { get; set; }

        public DbSet<Contractor> Contractor { get; set; }

        public DbSet<yard_management_system.Models.OrderContract> OrderContract { get; set; }
    }
}
