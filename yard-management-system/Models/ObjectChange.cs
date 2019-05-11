using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class ObjectChange
	{
		public int EntryId { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime ModifyDate { get; set; }
		public ICollection<User> UserEditor { get; set; }
		public ICollection<User> UserCreator { get; set; }
	}
}
