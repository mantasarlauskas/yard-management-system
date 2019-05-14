using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace yard_management_system.Models
{
	public class User
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string EMail { get; set; }
		public string PhoneNo { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public bool Blocked { get; set; }

		//public int UserRightID { get; set; }

		// Foreign key
		//public UserRight UserRight { get; set; }

		// Primary key
		public ICollection<Contractor> Contractor { get; set; }
		public ICollection<ObjectChange> UserIsCreator { get; set; }
		//public ICollection<PermissionsSet> PermissionsSets { get; set; }
	}

/*	public class UserCreator : User
	{
		public int UserIsCreatorID { get; set; }

		// Primary key
		public ICollection<ObjectChange> UserIsCreator { get; set; }
	}
	public class UserEditor : User
	{
		public int UserIsEditorID { get; set; }
	
		// Primary key
		public ICollection<ObjectChange> UserIsEditor { get; set; }

	}
	*/


}
