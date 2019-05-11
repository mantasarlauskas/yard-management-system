using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class PermissionsSet : ObjectChange
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public ICollection<Permission> Permissions { get; set; }

	}
}
