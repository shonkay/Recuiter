using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models



{
    public class Applicant : BaseModel
	{
		public User User { get; set; }

		public int? UserId { get; set; }

		public string Address { get; set; }

		//public Image Image { get; set; }

		//public int ImageId { get; set; }

		[DataType(DataType.PhoneNumber)]
		[DisplayName("Phone Number")]
		public string PhoneNumber { get; set; }

		public string Country { get; set; }

		public string City { get; set; }

		[DisplayName("Years Of Experience")]
		public int YearsOfExperience { get; set; }
		
		public int Age { get; set; }

		//public virtual ICollection<string> Languages { get; set; }

		[DisplayName("Education Level")]
		public MinimumQualificationType EducationLevel { get; set; }

		public string Bio { get; set; }

		public virtual ICollection<Document> Documents { get; set; }
	}
}