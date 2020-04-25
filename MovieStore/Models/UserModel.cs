using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;
//using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace MovieStore.Models
{
    
    public class UserModel
    {
        [Required]
        public string hoten { get; set; }
        [Required]
        public string diachi { get; set; }
        [Required]
        public string sdt { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is invalid!")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password is not match!!!")]
        public string ConfirmPassword { get; set; }
    }
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}