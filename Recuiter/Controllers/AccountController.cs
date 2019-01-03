using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Data.Models;
using Recuiter.CustomAuthentication;
using Recuiter.Context;
using Recruiter.CustomAuthentication;
using Recruiter.Context;

namespace Recruiter.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{


		// GET: Account
		public ActionResult Index()
		{
			ViewBag.Status = true;
			return View();
		}

		[HttpGet]
		public ActionResult Login(string ReturnUrl = "~/UserDashboard/Index")
		{
			if (User.Identity.IsAuthenticated)
			{
				return LogOut();
			}
			ViewBag.ReturnUrl = ReturnUrl;
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginView loginView, string ReturnUrl = "")
		{
			if (ModelState.IsValid)
			{
				if (Membership.ValidateUser(loginView.UserName, loginView.Password))
				{
					var user = (CustomMembershipUser)Membership.GetUser(loginView.UserName, false);
					if (user != null)
					{
						CustomSerializeModel userModel = new Data.Models.CustomSerializeModel()
						{
							UserId = user.UserId,
							FirstName = user.FirstName,
							LastName = user.LastName,
							RoleName = user.Roles.Select(r => r.Role.Name).ToList()
						};

						string userData = JsonConvert.SerializeObject(userModel);
						FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
							(
							1, loginView.UserName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
							);

						string enTicket = FormsAuthentication.Encrypt(authTicket);
						HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
						Response.Cookies.Add(faCookie);

					}

					if (Url.IsLocalUrl(ReturnUrl))
					{
						return Redirect(ReturnUrl);
					}
					else
					{
						return RedirectToAction("Index");
					}
				}
			}
			ModelState.AddModelError("", "Something Wrong : Username or Password invalid ");
			return View(loginView);
		}

		[HttpGet]
		public ActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Registration(RegistrationView registrationView)
		{
			bool statusRegistration = false;
			string messageRegistration = string.Empty;

			if (ModelState.IsValid)
			{
				// If E-mail Already Exists
				string userName = Membership.GetUserNameByEmail(registrationView.Email);
				if (!string.IsNullOrEmpty(userName))
				{
					ModelState.AddModelError("Warning Email", "Sorry: Email already Exists");
					return View(registrationView);
				}

				//Save User Data 
				using (RecruiterContext dbContext = new RecruiterContext())
				{
					var user = new User()
					{
						Username = registrationView.Username,
						FirstName = registrationView.FirstName,
						LastName = registrationView.LastName,
						Email = registrationView.Email,
						Password = registrationView.Password,
						CreatedDate = DateTime.Now,
						LastModifiedDate = DateTime.Now,
						//ActivationCode = Guid.NewGuid(),
					};

					dbContext.Users.Add(user);
					dbContext.SaveChanges();
				}

				//Verification Email
				/*VerificationEmail(registrationView.Email, registrationView.ActivationCode.ToString());*/
				messageRegistration = "Your account has been created successfully.";
				statusRegistration = true;
			}
			else
			{
				messageRegistration = "Something Wrong!";
			}
			ViewBag.Message = messageRegistration;
			ViewBag.Status = statusRegistration;

			return View(registrationView);
		}

		[HttpGet]
		[Authorize(Roles = "user,admin,hr")]
		public ActionResult ActivationAccount(string id)
		{


			bool statusAccount = false;
			using (RecruiterContext dbContext = new RecruiterContext())
			{
				//var userAccount = dbContext.Users.Where(u => u.ActivationCode.ToString().Equals(id)).FirstOrDefault();
				var userAccount = dbContext.Users.Where(u => u.Id.ToString().Equals(id)).FirstOrDefault();

				if (userAccount != null)
				{
					userAccount.IsActive = true;
					dbContext.SaveChanges();
					statusAccount = true;
				}
				else
				{
					ViewBag.Message = "Something Wrong !!";
				}

			}
			ViewBag.Status = statusAccount;
			return View();
		}

		public ActionResult LogOut()
		{
			HttpCookie cookie = new HttpCookie("Cookie1", "");
			cookie.Expires = DateTime.Now.AddYears(-1);
			Response.Cookies.Add(cookie);

			FormsAuthentication.SignOut();
			return RedirectToAction("Login", "Account", null);
		}

		[NonAction]
		public void VerificationEmail(string email, string activationCode, string emailFor = "VerifyAccount")
		{
			var url = string.Format("/Account/ActivationAccount/ emailFor/{0}", activationCode);
			var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);

			var fromEmail = new MailAddress("ebunsbsc@gmail.com", "Activation Account");
			var toEmail = new MailAddress(email);

			var fromEmailPassword = "NewPassword";// Please input your actual password
			string subject = "Activation Account !";

			string body = "<br/> Please click on the following link in order to activate your account" + "<br/><a href='" + link + "'> Activation Account ! </a>";

			if (emailFor == "VerifyAccount")
			{
				subject = "Your account is successfully created!";
				body = "<br/><br/> We are excited to tell you that your account has been" +
					"successfully created. Please click the link below" +
					"<br/><br/><a href='" + link + "'>" + link + "</a>";
			}
			else if (emailFor == "ResetPassword")
			{
				subject = "ResetPassword";
				body = "Hello, <br/>br/> Please click the link to reset your password" +
					"<br/><br/><a href=" + link + "> Reset Password link</a>";
			}
			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
			};

			using (var message = new MailMessage(fromEmail, toEmail)
			{
				Subject = subject,
				Body = body,
				IsBodyHtml = true

			})

				smtp.Send(message);


		}
		[HttpGet]
		public ActionResult ForgotPassword()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ForgotPassword(string EmailID)
		{
			//Verify Email ID
			//Generate Reset password link 
			//Send Email 
			string message = "";
			bool status = false;

			using (RecruiterContext dbContext = new RecruiterContext())
			{
				var Useraccount = dbContext.Users.Where(a => a.Email == EmailID).FirstOrDefault();
				if (Useraccount != null)
				{
					//Send email for reset password
					string resetCode = Guid.NewGuid().ToString();
					SendVerificationLinkEmail(Useraccount.Email, resetCode, "ResetPassword");
					Useraccount.ResetPasswordCode = resetCode;
					//This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
					//in our model class in part 1
					dbContext.Configuration.ValidateOnSaveEnabled = false;
					dbContext.SaveChanges();
					message = "Reset password link has been sent to your email id.";
				}
				else
				{
					message = "Account not found";
				}
			}
			ViewBag.Message = message;
			return View();
		}

		public void SendVerificationLinkEmail(string email, string resetCode, string v)
		{
			throw new NotImplementedException();
		}
		public ActionResult ResetPassword(string id)
		{
			//Verify the reset password link
			//Find account associated with this link
			//redirect to reset password page
			if (string.IsNullOrWhiteSpace(id))
			{
				return HttpNotFound();
			}

			using (RecruiterContext dc = new RecruiterContext())
			{
				var user = dc.Users.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
				if (user != null)
				{
					ResetPassword model = new ResetPassword();
					model.ResetCode = id;
					return View(model);
				}
				else
				{
					return HttpNotFound();
				}

			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ResetPassword(ResetPassword model)
		{
			var message = "";
			if (ModelState.IsValid)
			{
				using (RecruiterContext dc = new RecruiterContext())
				{
					var user = dc.Users.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
					if (user != null)
					{
						user.ResetPasswordCode = "";
						dc.Configuration.ValidateOnSaveEnabled = false;
						dc.SaveChanges();
						message = "New password updated successfully";
					}
				}
			}
			else
			{
				message = "Something invalid";
			}
			ViewBag.Message = message;
			return View(model);
		}
	}
}
