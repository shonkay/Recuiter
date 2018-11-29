using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
	public class User : BaseModel
	{

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public Department Department { get; set; }
		public int? DepartmentId { get; set; }
		public virtual ICollection<UserRole> Roles { get; set; }

	}
}