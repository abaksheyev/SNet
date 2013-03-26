using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SNet.Web.Models.Account
{
    public class RegistrationAccountModel
    {
       
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