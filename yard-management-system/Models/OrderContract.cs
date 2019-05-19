using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class OrderContract
	{
		public int ID { get; set; }

		public int CargoID { get; set; }
		public int ContractorID { get; set; }

		// Foreign key
		public Cargo Cargo { get; set; }
		public Contractor Contractor { get; set; }

		// Primary key
	}
}
