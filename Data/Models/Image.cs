using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
	public class Image
	{
		public int Id { get; set;}

		public string Title { get; set; }

		public User User { get; set; }

		public int UserId { get; set; }

		[DisplayName("Upload File")]
		public string ImagePath { get; set; }

		public HttpPostedFileBase ImageFile { get; set; }

	}
}
