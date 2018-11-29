using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recuiter.Models
{
	public class Application
	{
		public int Id { get; set; }
		public int JobId { get; set; }
		public string status { get; set; }
	}
}