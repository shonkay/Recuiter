using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recuiter.Models
{
	public class RegistrationQuestion
	{
		public int Id { get; set; }
		public string Questions { get; set; }
		public string ResponseType { get; set; }
	}
}