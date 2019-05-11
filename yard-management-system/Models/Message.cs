using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class Message
	{
		public int Id { get; set; }
		public string Text { get; set; }

		public ICollection<Contractor> Contractors { get; set; }
		public ICollection<Cargo> Cargo { get; set; }

	}
}
