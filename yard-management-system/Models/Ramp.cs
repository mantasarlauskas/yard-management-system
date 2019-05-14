using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace yard_management_system.Models
{
    public class Ramp : ObjectChange
	{
		public enum Category
		{
			C,
			CE,
			D,
			DE
		}

		public string Code { get; set; }
		public Category CategoryOfRamp { get; set; }
		public bool Blocked { get; set; }
		public DateTime BlockedFrom { get; set; }
		public DateTime BlockedTo { get; set; }

		// Foreign key

		// Primary key
		public ICollection<Cargo> Cargos { get; set; }
		public ICollection<TimeSlot> TimeSlots { get; set; }
	}
}
