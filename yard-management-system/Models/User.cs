using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string EMail { get; set; }
		public string PhoneNo { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public bool Blocked { get; set; }

		public int UserRightID { get; set; }

		// Foreign key
		public UserRight UserRight { get; set; }

		// Primary key
		public ICollection<Contractor> Contractor { get; set; }
		//public ICollection<PermissionsSet> PermissionsSets { get; set; }
		public ICollection<ObjectChange> UserCreator { get; set; }
		public ICollection<ObjectChange> UserEditor { get; set; }
	}
}
