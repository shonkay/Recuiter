using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class User
	{
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public User CreatedBy { get; set; }

        public int? CreatedById { get; set; }

        public User LastModifiedBy { get; set; }

        public int? LastModifiedById { get; set; }

        public bool IsDeleted { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

		public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

		public bool IsActive { get; set; }

		public Department Department { get; set; }

		public int? DepartmentId { get; set; }
		public virtual ICollection<UserRole> Roles { get; set; }
		public string ResetPasswordCode { get; set; }
	}
}