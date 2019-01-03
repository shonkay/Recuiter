using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Document //: BaseModel
	{
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public User User { get; set; }
		public int? UserId { get; set; }
		public string Name { get; set; }
		public string FilePath { get; set; }
		public FileType Type { get; set; }

        public virtual ICollection<Applicant> Applicants { get; set; }
	}
}