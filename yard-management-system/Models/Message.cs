using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class Message
	{
		public int ID { get; set; }
		public string Text { get; set; }

		public int CargoID { get; set; }

		// Foreign key
		public Cargo Cargo { get; set; }

		// Primary key
		public ICollection<MessageReceiver> MessageReceivers { get; set; }

	}
}
