using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yard_management_system.Models
{
	public class Permission
	{
		public int Id { get; set; }
		public bool Read { get; set; }
		public bool Create { get; set; }
		public bool Modify { get; set; }
		public bool Delete { get; set; }
		public PermissionObject PermissionName { get; set; }
		public enum PermissionObject
		{
			Rampa,
			Ivaziavimas,
			Uzsakymas,
			Naudotojas,
			Krovinys,
			Laiko_tarpsnis,
			Teisiu_rinkinys
		}
		public ICollection<PermissionsSet> PermissionsSet { get; set; }

	}
}
