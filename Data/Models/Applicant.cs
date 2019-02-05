﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Data.Models



{
    public class Applicant : BaseModel
	{
		public virtual User User { get; set; }

		public int UserId { get; set; }

		public string Address { get; set; }

		[DataType(DataType.PhoneNumber)]
		[DisplayName("Phone Number")]
		public string PhoneNumber { get; set; }

		public string Country { get; set; }

		public string City { get; set; }

		[DisplayName("Years Of Experience")]
		public ExperienceLevelType YearsOfExperience { get; set; }

		public int Age { get; set; }

		public string Languages { get; set; }

		[DisplayName("Education Level")]
		public MinimumQualificationType EducationLevel { get; set; }

		public string Bio { get; set; }

		public virtual ICollection<Education> PastEducation { get; set; }

		public virtual ICollection<Experience> WorkExperience { get; set; }

		public virtual ICollection<ApplicantDocument> ApplicantDocuments { get; set; }

		public virtual ICollection<Skill> Skills { get; set; }


		public virtual ICollection<Institution> Institutions { get; set; }

		public string Achievement { get; set; }


	}
}