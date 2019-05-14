using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace yard_management_system.Models
{
	public class TimeSlot
	{
		public enum TimeSlotType
		{
			aktyvus,
			pertrauka,
			specialus
		}

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeSlotID { get; set; }
		public DateTime Date { get; set; }
		public string TimeFrom { get; set; }
		public string TimeDuration { get; set; }
		public TimeSlotType TypeOfTimeSlot { get; set; }
		public bool Reserved { get; set; }
		public bool Blocked { get; set; }

		public int RampID { get; set; }

		// Foreign key
		public Ramp Ramp { get; set; }

		// Primary key
		public ICollection<CargoTimeSlot> CargoTimeSlots { get; set; }

		//public ICollection<Ramp> Ramp { get; set; }
		//public ICollection<Cargo> Cargos { get; set; }
	}
}
