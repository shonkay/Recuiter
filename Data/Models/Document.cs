using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recuiter.Models
{
	public class Document
	{
		public int Id { get; set; }
		public int ApplicantId { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
	}
}