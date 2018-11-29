using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Data.Models
{
	public class Department : BaseModel
	{

		public string Name { get; set; }
		public User Hod { get; set; }
		public int? HodId { get; set; }
	}
}