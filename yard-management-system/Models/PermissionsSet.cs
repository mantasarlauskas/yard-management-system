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

		public int UserRightID { get; set; }

		// Foreign key
		public UserRight UserRight { get; set; }

		// Primary key
		public ICollection<Permission> Permissions { get; set; }
	}
}
