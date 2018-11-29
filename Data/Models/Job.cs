using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recuiter.Models
{
	public class Job
	{
		
		public int Id { get; set; }
		public  int DepartmentId { get; set; }
		public string JobDescription { get; set; }
	}
}