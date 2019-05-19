using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class Contractor
	{
		public enum ContractorType
		{
			Vairuotojas,
			Koordinatorius,
			Sandėlininkas,
			Vadybininkas,
			Klientas
		}

		public int ID { get; set; }
		public ContractorType TypeOfContractor { get; set; }

		public int UserID { get; set; }

		// Foreign key
		public User User { get; set; }

		// Primary key
		public ICollection<OrderContract> OrderContracts { get; set; }
		public ICollection<MessageReceiver> MessageReceivers { get; set; }
	}
}
