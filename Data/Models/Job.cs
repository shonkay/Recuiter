using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
	public class Job : BaseModel
	{
		public int JobId { get; set; }
		public  Department Department { get; set; }
		public  int DepartmentId { get; set; }
		public string JobDescription { get; set; }
	}
}