using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class Contractor
	{
		public int Id { get; set; }
		public ContractorType TypeOfContractor { get; set; }
		public enum ContractorType
		{
			Vairuotojas,
			Koordinatorius,
			Sandėlininkas,
			Vadybininkas,
			Klientas
		}
		public ICollection<User> User { get; set; }
		public ICollection<Message> Messages { get; set; }
		public ICollection<Cargo> Cargos { get; set; }
	}
}
