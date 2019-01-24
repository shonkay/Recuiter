﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Data.Models
{
    public class LoginView
    {
        [Required]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Create Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class CustomSerializeModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> RoleName { get; set; }

    }

    public class RegistrationView
    {
        [Required(ErrorMessage = "User Name required")]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First Name required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Error : Confirm password does not match with password")]
        public string ConfirmPassword { get; set; }

		public Guid ActivationCode { get; set; }

		public bool IsEmailVerfied { get; set; }



	}
}