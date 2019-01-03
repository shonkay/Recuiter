﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recruiter.Controllers
{
	[Authorize]
	public class UserDashboardController : Controller
	{
		// GET: UserDashboard
		public ActionResult Index()
		{
			return View();
		}
	}
}