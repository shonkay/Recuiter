﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
	public class BaseModel
	{
		public int Id { get; set; }

		public bool IsDeleted { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime LastModifiedDate { get; set; }

		public User CreatedBy { get; set; }

		public int CreatedById { get; set; }

		public User LastModifiedBy { get; set; }

		public int LastModifiedById { get; set; }

	}
}
