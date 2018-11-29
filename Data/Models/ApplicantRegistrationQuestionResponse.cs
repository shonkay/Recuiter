using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recuiter.Models
{
	public class ApplicantRegistrationQuestionResponse
	{
		public int Id { get; set; }
		public int ResponseId { get; set; }
		public int RegistrationQuestionId { get; set; }
	}
}