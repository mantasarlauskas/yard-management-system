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

		// Foreign key

		// Primary key
		public ICollection<Contractor> Contractor { get; set; }
		public ICollection<ObjectChange> UserIsCreator { get; set; }
	}
}
