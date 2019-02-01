using Recruiter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recuiter.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
			RecruiterContext ctxt = new RecruiterContext();
			ctxt.Roles.ToList();

			return View();
        }
    }
}