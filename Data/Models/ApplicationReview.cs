using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recuiter.Models
{
	public class ApplicationReview
	{
		public int Id { get; set; }
		public  int UserId { get; set; }
		public int ApplicantId { get; set; }
	}
}