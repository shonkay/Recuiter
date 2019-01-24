using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruiter.ViewModels
{
	public class ApplicantResumeVM
	{
		public Education Education { get; set; }
		public Experience Experience { get; set; }
		public Skill Skill { get; set; }

	}

	public class Education
	{
		public string Qualification { get; set; }

		public int FromDate { get; set; }

		public int ToDate { get; set; }

		public string Institution { get; set; }

		public string CourseStudies { get; set; }

	}

	public class Experience
	{
		public string Title { get; set; }

		public int FromDate { get; set; }

		public int ToDate { get; set; }

		public string Company { get; set; }
	}



	public class Skill
	{

	}
}