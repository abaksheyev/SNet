using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SNet.Web.Attributes.Validations;

namespace SNet.Web.Models.Account
{
    public class RegistrationAccoutStep1Model : RegistrationAccoutStepBase
    {
        [RequiredLocalized]
        public string Email { get; set; }

        [RequiredLocalized]
        public string Username { get; set; }

        [RequiredLocalized]
        public string Password { get; set; }

        [RequiredLocalized]
        public string VerifyPassword { get; set; }

        [RequiredLocalized]
        public string Header { get; set; }
    }
}