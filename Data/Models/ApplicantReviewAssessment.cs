using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recuiter.Models
{
	public class ApplicantReviewAssessment
	{
		public int Id { get; set; }
		public int ReviewId { get; set; }
		public string Responses { get; set; }
		public  string Questions { get; set; }

	}
}