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

        public DbSet<yard_management_system.Models.User> User { get; set; }

        public DbSet<yard_management_system.Models.Message> Message { get; set; }

        public DbSet<yard_management_system.Models.Permission> Permission { get; set; }

        public DbSet<yard_management_system.Models.TimeSlot> TimeSlot { get; set; }
    }
}
