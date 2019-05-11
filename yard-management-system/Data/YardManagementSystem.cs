using yard_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace yard_management_system.Data
{
	public class YardManagementSystem : DbContext
	{
		public YardManagementSystem(DbContextOptions<YardManagementSystem> options) : base(options)
		{
		}
		public DbSet<ActionEntry> ActionEntries { get; set; }
		public DbSet<Cargo> Cargos { get; set; }
		public DbSet<Contractor> Contractors { get; set; }
		public DbSet<Entry> Entries { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<ObjectChange> ObjectChanges { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<PermissionsSet> PermissionsSets { get; set; }
		public DbSet<Ramp> Ramps { get; set; }
		public DbSet<TimeSlot> TimeSlots { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ActionEntry>().ToTable("ActionEntry");
			modelBuilder.Entity<Cargo>().ToTable("Cargo");
			modelBuilder.Entity<Contractor>().ToTable("Contractor");
			modelBuilder.Entity<Entry>().ToTable("Entry");
			modelBuilder.Entity<Message>().ToTable("Message");
			modelBuilder.Entity<ObjectChange>().ToTable("ObjectChange");
			modelBuilder.Entity<Permission>().ToTable("Permission");
			modelBuilder.Entity<PermissionsSet>().ToTable("PermissionsSet");
			modelBuilder.Entity<Ramp>().ToTable("Ramp");
			modelBuilder.Entity<TimeSlot>().ToTable("TimeSlot");
			modelBuilder.Entity<User>().ToTable("User");
		}
	}
}
