using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class ApplicantDocument
    {
        [Key, Column(Order = 1)]
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        [Key, Column(Order = 2)]
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}