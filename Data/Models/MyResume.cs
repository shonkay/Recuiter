using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
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
