﻿using Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace Recuiter.Context.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasOptional(x => x.CreatedBy).WithMany().HasForeignKey(x=> x.CreatedById).WillCascadeOnDelete(false);

            HasOptional(x => x.LastModifiedBy).WithMany().HasForeignKey(x=> x.LastModifiedById).WillCascadeOnDelete(false);
        }
    }


    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            HasRequired(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
        }
    }

    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            HasRequired(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
            HasRequired(x => x.LastModifiedBy).WithMany().WillCascadeOnDelete(false);
            HasRequired(x => x.User).WithMany().WillCascadeOnDelete(false);
            HasRequired(x => x.Role).WithMany().WillCascadeOnDelete(false);
        }
    }


    public class ApplicantDocumentMap : EntityTypeConfiguration<ApplicantDocument>
    {
        public ApplicantDocumentMap()
        {
          
        }
    }

    class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            HasRequired(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.LastModifiedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.HoD).WithMany().WillCascadeOnDelete(false);
        }

    }
    class ApplicantMap : EntityTypeConfiguration<Applicant>
    {
        public ApplicantMap()
        {
            HasOptional(x => x.CreatedBy).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.LastModifiedBy).WithMany().WillCascadeOnDelete(false);
			HasRequired(x => x.User).WithMany().WillCascadeOnDelete(false);
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
	class ImageMap : EntityTypeConfiguration<Image>
	{
		public ImageMap()
		{
			HasRequired(x => x.User).WithMany().WillCascadeOnDelete(false);
		}
	}
}