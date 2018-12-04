using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class User
	{
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public Department Department { get; set; }
		public int? DepartmentId { get; set; }
		//public virtual ICollection<UserRole> Roles { get; set; }
	}
}