using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SNet.Web.Models.Account
{
    public class RegistrationAccoutStep1Model
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string VerifyPassword { get; set; }

        public string Header { get; set; }
    }
}