using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public string Description { get; set; }
		public CargoState State { get; set; }

		public int RampID { get; set; }
		public int EntryID { get; set; }
		public int OrderID { get; set; }


		// Foreign key
		public Ramp Ramp { get; set; }
		public Entry Entry { get; set; }
		public Order Order { get; set; }

		//Primary key
		public ICollection<Message> Messages { get; set; }
		public ICollection<CargoTimeSlot> CargoTimeSlots { get; set; }
		public ICollection<OrderContract> OrderContracts { get; set; }
	}
}
