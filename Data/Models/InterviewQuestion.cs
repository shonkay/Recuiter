using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
	public class InterviewQuestion : BaseModel
	{
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        public string Question { get; set; }
        public bool IsGeneral { get; set; }
                                           //public string ResponseType { get; set; }
    }

	public class Question : BaseModel
	{
		public QuestionTemplate QuestionTemplate { get; set; }

		public int QuestionTemplateId { get; set; }

		public string QuestionText { get; set; }
		
		public bool IsTextResponse { get; set; }
	}

	public class QuestionTemplate : BaseModel
	{
		public string Name { get; set; }
		public Department Department { get; set; }
		public int? DepartmentId { get; set; }
	}
}