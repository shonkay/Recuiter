using Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace Recuiter.Context.Map
{
    public class DocumentMap:EntityTypeConfiguration<Document>
    {
        public DocumentMap()
        {
            HasRequired(x => x.User).WithMany().WillCascadeOnDelete(false);
        }
    }

    class DepartmentMap:EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            HasRequired(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.LastModifiedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.HoD).WithMany().WillCascadeOnDelete(false);
        }

    }
    class ApplicantMap:EntityTypeConfiguration<Applicant>
    {
        public ApplicantMap()
        {
            HasOptional(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.LastModifiedBy).WithMany().WillCascadeOnDelete(false);
        }
    }

    class ApplicationMap : EntityTypeConfiguration<Application>
    {
        public ApplicationMap()
        {
            HasOptional(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.LastModifiedBy).WithMany().WillCascadeOnDelete(false);

        }
    }

    class JobMap : EntityTypeConfiguration<Job>
    {
        public JobMap()
        {
            HasOptional(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.LastModifiedBy).WithMany().WillCascadeOnDelete(false);

        }
    }
    class ApplicationReviewMap : EntityTypeConfiguration<ApplicationReview>
    {
        public ApplicationReviewMap()
        {
            HasRequired(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.LastModifiedBy).WithMany().WillCascadeOnDelete(false);
            HasRequired(x => x.User).WithMany().WillCascadeOnDelete(false);
        }
    }


    class ApplicationReviewAssesmentMap : EntityTypeConfiguration<ApplicantReviewAssessment>
    {
        public ApplicationReviewAssesmentMap()
        {
            HasRequired(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.LastModifiedBy).WithMany().WillCascadeOnDelete(false);
        }
    }

    class InterViewQuestionMap : EntityTypeConfiguration<InterviewQuestion>
    {
        public InterViewQuestionMap()
        {
            HasRequired(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.LastModifiedBy).WithMany().WillCascadeOnDelete(false);
        }
    }
}