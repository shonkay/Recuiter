using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
	public class Document : BaseModel
	{
		public User User { get; set; }
		public int? UserId { get; set; }
		public string Name { get; set; }
		public FileType Type { get; set; }
	}
}