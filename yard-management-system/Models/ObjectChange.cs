using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace yard_management_system.Models
{
	public abstract class ObjectChange
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
		public DateTime CreationDate { get; set; }
		//public DateTime ModifyDate { get; set; }

		//public int UserEditorId { get; set; }
		public int UserCreatorID { get; set; }

		// Foreign key
		//public UserEditor UserEditor { get; set; }
	//	public UserCreator UserCreator { get; set; }
		public User UserCreator { get; set; }

		// Primary key
		//public ICollection<User> UserEditor { get; set; }
		//public ICollection<User> UserCreator { get; set; }
	}
}
