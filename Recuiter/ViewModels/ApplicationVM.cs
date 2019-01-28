using Data.Enums;
using System;
using System.Collections.Generic;

namespace Recruiter.ViewModels
{
    public class ApplicationVM
    {
        public ICollection<int>Id { get; set; }
        public string  JobTitle { get; set; }
        public DateTime Date { get; set; }
        public JobProcessStatus Statua { get; set; }
    }
}