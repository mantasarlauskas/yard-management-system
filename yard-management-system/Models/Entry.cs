using System;
using System.Collections.Generic;

namespace yard_management_system.Models
{
	public class Entry : ObjectChange
	{
		public string Code { get; set; }
		public bool Blocked { get; set; }
		public DateTime BlockedFrom { get; set; }
		public DateTime BlockedTo { get; set; }

		// Primary key
		public ICollection<Cargo> Cargos { get; set; }
	}
}
