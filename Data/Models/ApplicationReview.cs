﻿using System.Collections.Generic;

namespace Data.Models
{
    public class ApplicationReview :BaseModel
	{
        public virtual ICollection<ApplicantReviewAssessment> Reviews { get; set; }
        public int ReviewerId { get; set; }
        public User Reviewer { get; set; }
        public int ApplicationId { get; set; }
		public Application Application { get; set; }
	}

	public class ApplicationInterviewReview
	{
		public InterviewReviewer InterviewReviewer { get; set; }

		public User Reviewer { get; set; }

		public ApplicantInterview ApplicantInterview { get; set; }

		public string Comments { get; set; }
	}
}