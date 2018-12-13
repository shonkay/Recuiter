using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Data.Models
{
    public class Job : BaseModel
    {
        [Display(Name = "Job Id")]
        public int JobId { get; set; }
        [Display(Name = "Department")]
        public Department Department { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Job Title")]
        public string Title { get; set; } // Text Box
        [Display(Name = "Job Summary")]
        public string Summary { get; set; } // Text Area
        [Display(Name = "Job Description")]
        public string Description { get; set; }// Text Area
        [Display(Name = "Duties & Responsibilities")]
        public string Responsibility { get; set; }// Text Area
        [Display(Name = "General Requirement")]
        public string GeneralRequirement { get; set; } //Text Area
        [Display(Name = "Skill Set")]
        public string SkillSet { get; set; } //Text Area
        [Display(Name = "Minimum Academic Qualification")]
        public MinimumQualificationType MinimumQualification { get; set; }
        //[Display(Name = "Experience Length")]
        //public int? ExperienceLength { get; set; }
        [Display(Name = "Level of Expertise")]
        public ExperienceLevelType ExperienceLevel { get; set; }
        [Display(Name = "Year(s) of Experience")]
        [Range(0, 50)]
        public int ExperienceLength { get; set; }
        [Display(Name = "Contract Class")]
        public ContractClassType ContractClass { get; set; }
        [Display(Name = "Contract Length")]
        public string ContractLength { get; set; } // A combination of drop-down lists of Integer and month/year. Mutually exclusive on ContractType
        [Display(Name = "Expiry Date")]

        public DateTime ExpiryDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPublished { get; set; }
    }
}