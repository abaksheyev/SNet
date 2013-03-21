using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SNet.Web.Models.Account
{
    public class RegistrationAccountModel
    {
        #region -- Step#1 Create Account --

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Verify Password")]
        public string VerifyPassword { get; set; }

        #endregion

        #region-- Step#2 About You--

        [Display(Name = "BirthDay")]
        public string BirthDay { get; set; }
        
        #endregion

        #region-- Step#2 Terms--
        #endregion

        #region-- Step#2 reCaptcha--
        #endregion

        public string Header { get; set; }

        public RegistrationStep CurrentStep { get; set; }
    }

    public enum RegistrationStep
    {
        CreateAccount,
        AboutYou,
        Terms,
        ReCaptcha,
    }
}