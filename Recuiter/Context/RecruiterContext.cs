using Data.Models;
using Recuiter.Context.Map;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Recruiter.Context
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
		public IDbSet<UserRole> UserRoles { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());

			modelBuilder.Configurations.Add(new UserMap());
			modelBuilder.Configurations.Add(new UserRoleMap());
			modelBuilder.Configurations.Add(new RoleMap());
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

		public System.Data.Entity.DbSet<Data.Models.Role> Roles { get; set; }



		public System.Data.Entity.DbSet<Data.Models.Image> Images { get; set; }
		public IEnumerable Document { get; internal set; }

		public System.Data.Entity.DbSet<Recruiter.ViewModels.ApplicantProfileViewModels> ApplicantProfileViewModels { get; set; }
	}
}