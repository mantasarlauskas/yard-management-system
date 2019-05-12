using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class Cargo
	{
		public enum CargoState
		{
			ruošiamas,
			išvykęs,
			vėluojantis,
			atvykęs,
			iškrautas
		}

		public int ID { get; set; }
		public string RegistrationNumber { get; set; }
		public string Weight { get; set; }
		public string Description { get; set; }
		public CargoState State { get; set; }

		public int RampID { get; set; }
		public int EntryID { get; set; }
		public int OrderID { get; set; }
		public int OrderContractID { get; set; }
		public int CargoTimeSlotID { get; set; }


		// Foreign key
		public Ramp Ramp { get; set; }
		public Entry Entry { get; set; }
		public Order Order { get; set; }
		public OrderContract OrderContract { get; set; }
		public CargoTimeSlot CargoTimeSlot { get; set; }

		//Primary key
		//public ICollection<Contractor> Contractors { get; set; }
		public ICollection<Message> Messages { get; set; }
		//public ICollection<TimeSlot> TimeSlots { get; set; }

	}
}
