using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recruiter.Context;

namespace Recruiter.Controllers
{
	[Authorize]
	public class UserDashboardController : Controller
	{
		private RecruiterContext db = new RecruiterContext();

		// GET: UserDashboard
		public ActionResult Index()
		{
			return View();
		}
	}
}