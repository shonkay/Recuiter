using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
	public class ApplicantReviewAssessment : BaseModel
    {
        public int InterviewQuestionId { get; set; }
        public InterviewQuestion InterviewQuestion { get; set; }
        public int ApplicationReviewId { get; set; }
        public ApplicationReview ApplicationReview { get; set; }
        public string Response { get; set; }

	}
}