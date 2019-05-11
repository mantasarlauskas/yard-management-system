using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yard_management_system.Models;

namespace yard_management_system.Data
{
	public class DbInitializer
	{
		public static void Initialize(YardManagementSystem context)
		{
			context.Database.EnsureCreated();

			if (context.Orders.Any())
			{
				return;   // DB has been seeded
			}

			var orders = new Order[]
			{
				new Order{Id=0, State= Order.OrderState.ruošiamas}
			};
			foreach (Order x in orders)
			{
				context.Orders.Add(x);
			}
			context.SaveChanges();

			var cargo = new Cargo[]
			{
				new Cargo{
					Id =0,
					RegistrationNumber="FEE757",
					Weight="1300",
					Description="Plytos",
					State=Cargo.CargoState.ruošiamas
					},
				new Cargo{
					Id =1,
					RegistrationNumber="FEE757",
					Weight="150",
					Description="Cementas",
					State=Cargo.CargoState.ruošiamas
					}
			};
			foreach (Cargo x in cargo)
			{
				context.Cargos.Add(x);
			}
			context.SaveChanges();

			var contractors = new Contractor[]
			{
				new Contractor{
					Id=0,
					TypeOfContractor=Contractor.ContractorType.Vadybininkas
					}
			};
			foreach (Contractor x in contractors)
			{
				context.Contractors.Add(x);
			}
			context.SaveChanges();
			
			var entries = new Entry[]
			{
				new Entry{
					Id=0,
					Code="E1",
					Blocked=false,
					BlockedFrom=new DateTime(),
					BlockedTo=new DateTime()
					}
			};
			foreach (Entry x in entries)
			{
				context.Entries.Add(x);
			}
			context.SaveChanges();

			var messages = new Message[]
			{
				new Message{
					Id=0,
					Text=null
					}
			};
			foreach (Message x in messages)
			{
				context.Messages.Add(x);
			}
			context.SaveChanges();

			var changes = new ObjectChange[]
			{
				new ObjectChange{
					EntryId=0,
					CreationDate=new DateTime(),
					ModifyDate=new DateTime()
					}
			};
			foreach (ObjectChange x in changes)
			{
				context.ObjectChanges.Add(x);
			}
			context.SaveChanges();

			var permissions = new Permission[]
			{
				new Permission{
					Id=0,
					Read=true,
					Create=true,
					Modify=true,
					Delete=true,
					PermissionName=Permission.PermissionObject.Uzsakymas
					}
			};
			foreach (Permission x in permissions)
			{
				context.Permissions.Add(x);
			}
			context.SaveChanges();

			var permissionsSet = new PermissionsSet[]
			{
				new PermissionsSet{
					Id=0,
					Code="ADMIN",
					Description="Administrator role",
					}
			};
			foreach (PermissionsSet x in permissionsSet)
			{
				context.PermissionsSets.Add(x);
			}
			context.SaveChanges();

			var ramps = new Ramp[]
			{
				new Ramp{
					Id=0,
					Code="R1",
					CategoryOfRamp= Ramp.Category.DE,
					Blocked =false,
					BlockedFrom= new DateTime(),
					BlockedTo=new DateTime()
					},
				new Ramp{
					Id=1,
					Code="R2",
					CategoryOfRamp= Ramp.Category.D,
					Blocked =false,
					BlockedFrom= new DateTime(),
					BlockedTo=new DateTime()
					},
			};
			foreach (Ramp x in ramps)
			{
				context.Ramps.Add(x);
			}
			context.SaveChanges();

			var timeSlots = new TimeSlot[]
			{
				new TimeSlot{
					Id=0,
					Date =DateTime.Parse("2019-05-11"),
					TimeFrom = "09:00",
					TimeDuration ="90",
					TypeOfTimeSlot =TimeSlot.TimeSlotType.aktyvus,
					Reserved =false,
					Blocked =false,
					},
				new TimeSlot{
					Id=1,
					Date =DateTime.Parse("2019-05-11"),
					TimeFrom = "10:30",
					TimeDuration ="30",
					TypeOfTimeSlot =TimeSlot.TimeSlotType.pertrauka,
					Reserved =false,
					Blocked =false,
					},
				new TimeSlot{
					Id=2,
					Date =DateTime.Parse("2019-05-11"),
					TimeFrom = "11:00",
					TimeDuration ="90",
					TypeOfTimeSlot =TimeSlot.TimeSlotType.aktyvus,
					Reserved =false,
					Blocked =false,
					},
				new TimeSlot{
					Id=3,
					Date =DateTime.Parse("2019-05-11"),
					TimeFrom = "12:30",
					TimeDuration ="1",
					TypeOfTimeSlot =TimeSlot.TimeSlotType.pertrauka,
					Reserved =false,
					Blocked =false,
					},
			};
			foreach (TimeSlot x in timeSlots)
			{
				context.TimeSlots.Add(x);
			}
			context.SaveChanges();

			var user = new User[]
			{
				new User{
					Id=0,
					UserName="auscep1",
					Password="admin",
					EMail="auscep1@ktu.edu",
					PhoneNo="86123456",
					FirstName="Ausra",
					SecondName="Cepulionyte",
					Blocked =false
					},
				new User{
					Id=0,
					UserName="manarl",
					Password="admin",
					EMail="manarl@ktu.edu",
					PhoneNo="86123457",
					FirstName="Mantas",
					SecondName="Arlauskas",
					Blocked =false
					},
			};
			foreach (User x in user)
			{
				context.Users.Add(x);
			}
			context.SaveChanges();
		}
	}
}
