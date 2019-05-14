using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class CargoTimeSlot
	{
		public int ID { get; set; }

		public int CargoID { get; set; }
		public int TimeSlotID { get; set; }

		// Foreign key
		public Cargo Cargo { get; set; }
		public TimeSlot TimeSlot { get; set; }

		// Primary key
	//	public ICollection<TimeSlot> TimeSlots { get; set; }

	}
}
