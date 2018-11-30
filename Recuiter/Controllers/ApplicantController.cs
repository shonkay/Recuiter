using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recuiter.Models;

namespace Recuiter.Controllers
{
	public class ApplicantController : Controller
	{
		// GET: Applicant
		public ActionResult Applicant()
		{
			//var applicant = new Applicant() {FirstName = "Adam", };
			return View();
		}

	}
}