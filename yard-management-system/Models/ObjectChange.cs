using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace yard_management_system.Models
{
	public abstract class ObjectChange
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
		public DateTime CreationDate { get; set; }

		public int UserCreatorID { get; set; }

		// Foreign key
		public User UserCreator { get; set; }

		// Primary key
	}
}
