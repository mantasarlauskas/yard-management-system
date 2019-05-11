using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class Entry :ObjectChange
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public bool Blocked { get; set; }
		public DateTime BlockedFrom { get; set; }
		public DateTime BlockedTo { get; set; }

		public ICollection<Cargo> Cargos { get; set; }
	}
}
