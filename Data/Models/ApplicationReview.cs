using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
	public class ApplicationReview :BaseModel
	{
        public virtual ICollection< ApplicantReviewAssessment > Reviews { get; set; }
		public  int UserId { get; set; }
		public  User User { get; set; }
		public int ApplicationId { get; set; }
		public Application Application { get; set; }
	}
}