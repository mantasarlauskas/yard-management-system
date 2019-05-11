using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class Order : ObjectChange
	{
		public int Id { get; set; }
		public OrderState State { get; set; }
		public enum OrderState
		{
			ruošiamas,
			patvirtintas,
			įvykdytas,
			atmestas
		}
		public ICollection<Cargo> Cargos { get; set; }

	}
}
