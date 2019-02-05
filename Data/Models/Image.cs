using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
	public class Image : BaseModel
	{
	
		public string Title { get; set; }

		public User User { get; set; }

		public int UserId { get; set; }

		[DisplayName("Upload File")]
		public string ImagePath { get; set; }

		[NotMapped]
		public HttpPostedFileBase ImageFile { get; set; }

	}
}
