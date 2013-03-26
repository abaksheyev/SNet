using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Recaptcha;
using SNet.Web.Models;
using SNet.Web.Models.Account;

namespace SNet.Web.Controllers
{
    public partial class AccountController : BaseController
    {
        public virtual ActionResult Index()
        {
            return View(MVC.Account.Views.Registration.Step1_CreateAccountView, new RegistrationAccoutStep1Model());
        }

        [HttpGet]
        private ActionResult Registration()
        {
            return PartialView();
        }

        public virtual ActionResult RegistrationProcessing(RegistrationAccountModel model, string submit = "step1")
        {
            switch (submit)
            {
                case "step2":
                    return Step2_AboutYouView(model);
                    break;
                case "step3":
                    return Step3_TermsView(model);
                    break;
                case "step4":
                    return Step4_reCaptchaView(model);
                default:
                    return Step1_CreateAccountView(model);
            }
        }


        #region -- Steps --

        private ActionResult Step1_CreateAccountView(RegistrationAccountModel model)
        {
            var modelView = new RegistrationAccoutStep1Model();

            return View(MVC.Account.Views.Registration.Step1_CreateAccountView, modelView);
        }

        private ActionResult Step2_AboutYouView(RegistrationAccountModel model)
        {
            model.Header = "AboutYou";
            model.CurrentStep = RegistrationStep.AboutYou;
            return View(MVC.Account.Views.Registration.Step2_AboutYouView, model);
        }

        private ActionResult Step3_TermsView(RegistrationAccountModel model)
        {
            model.Header = "Terms";
            model.CurrentStep = RegistrationStep.Terms;
            return View(MVC.Account.Views.Registration.Step3_TermsView, model);
        }


        [RecaptchaControlMvc.CaptchaValidator]
        [HttpPost]
        private ActionResult Step4_reCaptchaView(RegistrationAccountModel model)
        {
            model.Header = "reCaptcha";
            model.CurrentStep = RegistrationStep.ReCaptcha;
            return View(MVC.Account.Views.Registration.Step4_reCaptchaView, model);
        }

        [RecaptchaControlMvc.CaptchaValidator]
        [HttpPost]
        private ActionResult Step4_reCaptchaView(RegistrationAccountModel model, bool captchaValid, string captchaErrorMessage)
        {
            model.Header = "reCaptcha";
             model.CurrentStep = RegistrationStep.ReCaptcha;
            return View(MVC.Account.Views.Registration.Step4_reCaptchaView, model);
        }

        #endregion
    }
}
