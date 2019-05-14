using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public abstract class ObjectChange
	{
		public int ID { get; set; }
		public DateTime CreationDate { get; set; }
		//public DateTime ModifyDate { get; set; }

		//public int UserEditorId { get; set; }
		public int UserCreatorId { get; set; }

		// Foreign key
		//public UserEditor UserEditor { get; set; }
	//	public UserCreator UserCreator { get; set; }
		public User UserCreator { get; set; }

		// Primary key
		//public ICollection<User> UserEditor { get; set; }
		//public ICollection<User> UserCreator { get; set; }
	}
}
