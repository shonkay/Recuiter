﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
	public class Application : BaseModel
	{   
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
		public Job Job { get; set; }
		public int JobId { get; set; }
		public string Status { get; set; }
	}
}