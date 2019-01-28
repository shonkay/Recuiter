using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Data.Models;
using Recruiter.Context;
using Recruiter.CustomAuthentication;
using Recruiter.ViewModels;

namespace Recruiter.Controllers
{

	public class ApplicantsController : Controller
	{
		private RecruiterContext db = new RecruiterContext();
		//private readonly object applicationProfileViewModel;

		[HttpGet]
		public ActionResult Index(string searchString, string searchSkills, string searchContract, int? ContractClass, int? ExperienceLevel)
		{
			var jobss = from j in db.Jobs.Include(x => x.Department) select j;

			if (!String.IsNullOrEmpty(searchString))
			{
				jobss = jobss.Where(s => s.Title.Contains(searchString));
			}

			if (!String.IsNullOrEmpty(searchSkills))
			{
				jobss = jobss.Where(s => s.SkillSet.Contains(searchSkills));
			}

			if (ContractClass != null)
			{
				jobss = jobss.Where(x => x.ContractClass == (ContractClassType)ContractClass);


				ViewBag.SearchFilter = new Search { Contract = ContractClass };

			}

			if (ExperienceLevel != null)
			{
				jobss = jobss.Where(x => x.ExperienceLevel == (ExperienceLevelType)ExperienceLevel);

				ViewBag.SearchFilter = new Search { Expereince = ExperienceLevel };
			}

			//var jobList = new List<JobViewModel>();
			//foreach(Job job in jobsss)
			//{

			//	var jobView = new JobViewModel
			//	{
			//		Id = job.Id,
			//		JobId = job.JobId,
			//		DepartmentId = job.DepartmentId,
			//		Title = job.Title,
			//		Summary = job.Summary,
			//		Description = job.Description,
			//		Responsibility = job.Responsibility,
			//		GeneralRequirement = job.GeneralRequirement,
			//		SkillSet = job.SkillSet,
			//		MinimumQualification = job.MinimumQualification,
			//		ExperienceLevel = job.ExperienceLevel,
			//		ExperienceLength = job.ExperienceLength,
			//		ContractClass = job.ContractClass,
			//		ExpiryDate = job.ExpiryDate
			//	};
			//jobList.Add(jobView);
			//}
			return View(jobss.ToList());
		}

		public ActionResult ApplicantProfileEditReadOnly()
		{

			var currentUserId = (Membership.GetUser(User.Identity.Name) as CustomMembershipUser).UserId;
			using (RecruiterContext dbContext = new RecruiterContext())
			{
				////var user = (from u in dbContext.Users where u.Id == currentUserId select u).FirstOrDefault();
				//var applicant = (from p in dbContext.Applicants.Include(x=> x.User)
				//				 .Include(x=> x.ApplicantDocuments)
				//				 where p.UserId == currentUserId
				//				 select new ApplicantProfileViewModels
				//				 {
				//					 Age = p.Age,
				//					 Bio = p.Bio,
				//					 EducationLevel = p.EducationLevel,
				//					 Certificates = p.ApplicantDocuments.Select(x => new ApplicantDocumentViewModel
				//					 {
				//						 FilePath = x.FilePath,
				//						 Name = x.Name,
				//						 Type = x.Type
				//					 }).ToList()
				//				 }).FirstOrDefault();

				//// learn how to join tables using linq;
				var query = (from p in dbContext.Applicants.Include(x => x.User)
							 where p.UserId == currentUserId
							 select new ApplicantProfileViewModels
							 {
								 Age = p.Age,
								 Bio = p.Bio,
								 EducationLevel = p.EducationLevel,
								 FirstName = p.User.FirstName,
								 LastName = p.User.LastName,
								 Certificates = (from files in dbContext.ApplicantDocuments
												 where files.ApplicantId == p.Id && files.Type == FileType.Certificate && !files.IsDeleted
												 select new ApplicantDocumentViewModel
												 {
													 FilePath = files.FilePath,
													 Name = files.Name,
													 Type = files.Type
												 }).ToList()
							 }).FirstOrDefault();


				return View(query);
			}
		}


		[HttpGet]
		// GET: Applicants
		public ActionResult ApplicantProfileEdit()
		{
			var currentUserId = (Membership.GetUser(User.Identity.Name) as CustomMembershipUser).UserId;
			using (RecruiterContext dbContext = new RecruiterContext())
			{
				var query = (from p in dbContext.Applicants.Include(x => x.User)
							 where p.UserId == currentUserId
							 select new ApplicantProfileViewModels
							 {
								 Age = p.Age,
								 Bio = p.Bio,
								 PhoneNumber = p.PhoneNumber,
								 Email = p.User.Email,
								 City = p.City,
								 Country = p.Country,
								 CompleteAddress = p.Address,

								 YearsOfExperience = p.YearsOfExperience,

								 EducationLevel = p.EducationLevel,
								 FirstName = p.User.FirstName,
								 LastName = p.User.LastName,

								 Certificates = (from files in dbContext.ApplicantDocuments
												 where files.ApplicantId == p.Id && files.Type == FileType.Certificate && !files.IsDeleted
												 select new ApplicantDocumentViewModel
												 {
													 FilePath = files.FilePath,
													 Name = files.Name,
													 Type = files.Type
												 }).ToList()
							 }).FirstOrDefault();


				return View(query);
			}

		}


		[HttpPost]
		public ActionResult ApplicantProfileEdit(ApplicantProfileViewModels applicantProfileViewModel)
		{
			if (ModelState.IsValid)
			{
				var currentUserId = (Membership.GetUser(User.Identity.Name) as CustomMembershipUser).UserId;
				using (RecruiterContext dbContext = new RecruiterContext())
				{

					var applicant = dbContext.Applicants.Where(a => a.UserId == currentUserId).FirstOrDefault();

					if (applicant != null)
					{
						applicant.PhoneNumber = applicantProfileViewModel.PhoneNumber;
						applicant.Address = applicantProfileViewModel.CompleteAddress;
						applicant.Age = applicantProfileViewModel.Age;
						applicant.Country = applicantProfileViewModel.Country;
						applicant.City = applicantProfileViewModel.City;
						applicant.Bio = applicantProfileViewModel.Bio;
						applicant.EducationLevel = applicantProfileViewModel.EducationLevel;
						applicant.YearsOfExperience = applicantProfileViewModel.YearsOfExperience;


						dbContext.SaveChanges();
					}
					else if (applicant == null)
					{
						var appnew = new Applicant()
						{
							PhoneNumber = applicant.PhoneNumber,
						};
						dbContext.Applicants.Add(appnew);
						dbContext.SaveChanges();
					}
					else
					{
						ModelState.AddModelError("Warning Error", "Information is not correct");
						return View(applicantProfileViewModel);
					}

				}

			}
			return RedirectToAction("ApplicantProfilePage");
		}

		[HttpPost]
		public ActionResult ApplicantResumeProfile(ApplicantProfileViewModels applicantProfileViewModel)
		{
			if (ModelState.IsValid)
			{
				var currentUserId = (Membership.GetUser(User.Identity.Name) as CustomMembershipUser).UserId;
				using (RecruiterContext dbContext = new RecruiterContext())
				{
					var applicantEntity = dbContext.Applicants.Where(a => a.UserId == currentUserId).Include(x => x.User).Include(x => x.PastEducation).Include(x => x.Skills).Include(x => x.ApplicantDocuments)
								 .Include(x => x.Institutions).FirstOrDefault();

					if (applicantEntity == null)
					//var   returnapp = new ApplicantResumeVM

					{
						applicantEntity.PastEducation.Select(edu => new ViewModels.Education
						{
							Qualification = edu.Qualification,
							FromDate = edu.FromDate,
							ToDate = edu.ToDate,
							Institution = edu.Institution,
							CourseStudies = edu.CourseStudied,
						});

						applicantEntity.WorkExperience.Select(edx => new ViewModels.Experience
						{
							Title = edx.Title,
							FromDate = edx.FromDate,
							ToDate = edx.ToDate,
							Company = edx.CompanyName,
						});

						applicantEntity.Skills.Select(skill => new ViewModels.Skill
						{
							Achievement = skill.Achievement,
							Id = skill.Id,
							Skilllevel = skill.Skilllevel
						});

						dbContext.Applicants.Add(applicantEntity);
						dbContext.SaveChanges();
					}
					else
					{
						ModelState.AddModelError("Warning Error", "Information is not correct");
						return View(applicantProfileViewModel);
					}
				}

			}
			return View(applicantProfileViewModel);
		}




		[HttpGet]
		public ActionResult ApplicantProfilePage()
		{
			var loggedInUserId = (Membership.GetUser(User.Identity.Name) as CustomMembershipUser).UserId;
			using (RecruiterContext dbContext = new RecruiterContext())
			{
				var check = (from p in dbContext.Applicants.Include(x => x.User).Include(x => x.PastEducation).Include(x => x.Skills).Include(x => x.ApplicantDocuments)
							 .Include(x => x.Institutions).Include(x => x.Languages)
							 where p.UserId == loggedInUserId

							 select new ApplicantProfileViewModels
							 {
								 Country = p.Country,
								 City = p.City,
								 CompleteAddress = p.Address,
								 Achievement = p.Achievement,
								 Age = p.Age,
								 Bio = p.Bio,
								 EducationLevel = p.EducationLevel,
								 FirstName = p.User.FirstName,
								 LastName = p.User.LastName,
								 Language = p.Languages,
								 Certificates = (from files in dbContext.ApplicantDocuments
												 where files.ApplicantId == p.Id && files.Type == FileType.Certificate && !files.IsDeleted
												 select new ApplicantDocumentViewModel
												 {
													 FilePath = files.FilePath,
													 Name = files.Name,
													 Type = files.Type
												 }).ToList(),
								 // Language = dbContext.Languages.Select(x => x.ApplicantId == p.Id, new Language { Name=})
								 //Skills = (from details in dbContext.Applicants
								 //	   where details.A )

							 }).FirstOrDefault();

				return View(check);

			return View();
		}




		// GET: Applicants/Details/5
		public ActionResult Details(int? id)
		{

			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Applicant applicant = db.Applicants.Find(id);
			if (applicant == null)
			{
				return HttpNotFound();
			}
			return View(applicant);
		}

		// GET: Applicants/Create
		public ActionResult Create()
		{
			ViewBag.CreatedById = new SelectList(db.Users, "Id", "Username");
			ViewBag.LastModifiedById = new SelectList(db.Users, "Id", "Username");
			ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
			return View();
		}



		// POST: Applicants/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,UserId,Address,PhoneNumber,Country,City,YearsOfExperience,Age,EducationLevel,Bio,IsDeleted,CreatedDate,LastModifiedDate,CreatedById,LastModifiedById")] Applicant applicant)
		{
			if (ModelState.IsValid)
			{
				db.Applicants.Add(applicant);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.CreatedById = new SelectList(db.Users, "Id", "Username", applicant.CreatedById);
			ViewBag.LastModifiedById = new SelectList(db.Users, "Id", "Username", applicant.LastModifiedById);
			ViewBag.UserId = new SelectList(db.Users, "Id", "Username", applicant.UserId);
			return View(applicant);
		}

		// GET: Applicants/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Applicant applicant = db.Applicants.Find(id);
			if (applicant == null)
			{
				return HttpNotFound();
			}
			ViewBag.CreatedById = new SelectList(db.Users, "Id", "Username", applicant.CreatedById);
			ViewBag.LastModifiedById = new SelectList(db.Users, "Id", "Username", applicant.LastModifiedById);
			ViewBag.UserId = new SelectList(db.Users, "Id", "Username", applicant.UserId);
			return View(applicant);
		}

		// POST: Applicants/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,UserId,Address,PhoneNumber,Country,City,YearsOfExperience,Age,EducationLevel,Bio,IsDeleted,CreatedDate,LastModifiedDate,CreatedById,LastModifiedById")] Applicant applicant)
		{
			if (ModelState.IsValid)
			{
				db.Entry(applicant).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.CreatedById = new SelectList(db.Users, "Id", "Username", applicant.CreatedById);
			ViewBag.LastModifiedById = new SelectList(db.Users, "Id", "Username", applicant.LastModifiedById);
			ViewBag.UserId = new SelectList(db.Users, "Id", "Username", applicant.UserId);
			return View(applicant);
		}

		// GET: Applicants/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Applicant applicant = db.Applicants.Find(id);
			if (applicant == null)
			{
				return HttpNotFound();
			}
			return View(applicant);
		}

		// POST: Applicants/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Applicant applicant = db.Applicants.Find(id);
			db.Applicants.Remove(applicant);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);

		}
	}
}

	//[HttpGet]
	//	public ActionResult UploadImage()
	//	{
	//		return View();
	//	}
	//}

