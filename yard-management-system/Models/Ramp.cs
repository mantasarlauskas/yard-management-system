using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

		public int RampID { get; set; }
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
