using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class Cargo
	{
		public int Id { get; set; }
		public string RegistrationNumber { get; set; }
		public string Weight { get; set; }
		public string Description { get; set; }
		public CargoState State { get; set; }
		public enum  CargoState
		{
			ruošiamas,
			išvykęs,
			vėluojantis,
			atvykęs,
			iškrautas
		}
		public ICollection<Ramp> Ramp { get; set; }
		public ICollection<Entry> Entry { get; set; }
		public ICollection<Order> Order { get; set; }
		public ICollection<Contractor> Contractors { get; set; }
		public ICollection<Message> Messages { get; set; }
		public ICollection<TimeSlot> TimeSlots { get; set; }

	}
}
