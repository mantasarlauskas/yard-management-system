﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class UserRight
	{
		public int ID { get; set; }
		public int UserID { get; set; }

		// Foreign key
		public User User { get; set; }

		// Primary key
		public ICollection<User> Users { get; set; }
		public ICollection<PermissionsSet> PermissionsSets { get; set; }
	}
}
