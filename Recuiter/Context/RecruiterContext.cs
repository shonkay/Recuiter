using Data.Models;
using Recuiter.Context.Map;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Recuiter.Context
{
    public class RecruiterContext : DbContext
    {
        public IDbSet<Applicant> Applicants { get; set; }
        public IDbSet<Job> Jobs { get; set; }
        public IDbSet<Document> Documents { get; set; }
        public IDbSet<ApplicantDocument> ApplicantDocuments { get; set; }
        public IDbSet<ApplicationReview> ApplicationReviews { get; set; }
        public IDbSet<Application> Applications { get; set; }
        public IDbSet<Department> Departments { get; set; }
        public IDbSet<ApplicantReviewAssessment> ApplicantReviewAssessments { get; set; }
        public IDbSet<InterviewQuestion> InterviewQuestions { get; set; }
        public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());

            modelBuilder.Configurations.Add(new DocumentMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new ApplicantMap());
            modelBuilder.Configurations.Add(new ApplicationMap());
            modelBuilder.Configurations.Add(new JobMap());
            modelBuilder.Configurations.Add(new ApplicationReviewMap());
            modelBuilder.Configurations.Add(new ApplicationReviewAssesmentMap());
            modelBuilder.Configurations.Add(new InterViewQuestionMap());

        }

        public RecruiterContext()
        {
           
        }

       
    }
}