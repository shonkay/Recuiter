using System;
using System.Collections.Generic;

namespace Data.Models



{
    public class Applicant : BaseModel 
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }

       public virtual ICollection<Document> Documents { get; set; }
	}
}