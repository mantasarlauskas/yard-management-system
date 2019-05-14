using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class MessageReceiver
	{
		public int ID { get; set; }
		public int MessageID { get; set; }
		public int ContractorID { get; set; }

		// Foreign key
		public Message Message { get; set; }
		public Contractor Contractor { get; set; }
		// Primary key
		//public ICollection<Message> Messages { get; set; }
		//public ICollection<Contractor> Contractors { get; set; }

	}
}
