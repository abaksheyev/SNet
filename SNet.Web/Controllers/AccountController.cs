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
using SNet.DomainServices.Interfaces;
using AutoMapper;
using SNet.Common.DomainModels;
using SNet.Common;

namespace SNet.Web.Controllers
{
    public partial class AccountController : BaseController
    {
        #region Constants

        private const string CURRENT_REGISTRATION_MODEL = "CURRENT_REGISTRATION_MODEL";

        #endregion

        #region Private Fields

        IAccountService _аccountService;

        #endregion

        public AccountController()
        {
        }

        public AccountController(IAccountService accountService)
        {
            _аccountService = accountService;
        }

       
        public virtual ActionResult Registration()
        {
            if (Session!=null && Session[CURRENT_REGISTRATION_MODEL] == null)
            {
                Session[CURRENT_REGISTRATION_MODEL] = new RegistrationModel();
            }

            return RegistrationProcessing("step1");
        }

        public virtual ActionResult RegistrationProcessing(string nextStep)
        {
            var regData = Session[CURRENT_REGISTRATION_MODEL] as RegistrationModel;

            switch (nextStep)
            {
                case "step1":
                    return PartialView(MVC.Account.Views.Registration.Step1_CreateAccountView, regData.Step1);
                case "step2":
                    return PartialView(MVC.Account.Views.Registration.Step2_AboutYouView, regData.Step2);
                case "step3":
                    return PartialView(MVC.Account.Views.Registration.Step3_TermsView, regData.Step3);
                case "step4":
                    return PartialView(MVC.Account.Views.Registration.Step4_reCaptchaView);
                case "finish":
                    return PartialView(MVC.Account.Views.Registration.Step5_Finish);
                default:
                    throw new NotImplementedException("Step Does Not Exist");
            }
        }

        #region -- Steps --

        [HttpPost]
        private ActionResult Step1_CreateAccountView(RegistrationAccoutStep1Model model, string nextStep = "step#1")
        {
            if (!ModelState.IsValid)
            {
                return View(MVC.Account.Views.Registration.Step1_CreateAccountView, model);
            }

            return RegistrationProcessing(nextStep);
        }

        [HttpPost]
        private ActionResult Step2_AboutYouView(RegistrationAccoutStep2Model model, string nextStep = "step#1")
        {
            if (!ModelState.IsValid)
            {
                return View(MVC.Account.Views.Registration.Step1_CreateAccountView, model);
            }

            return RegistrationProcessing(nextStep);
        }

        [HttpPost]
        private ActionResult Step3_TermsView(RegistrationAccoutStep3Model model, string nextStep = "step#1")
        {
            if (!ModelState.IsValid)
            {
                return View(MVC.Account.Views.Registration.Step1_CreateAccountView, model);
            }

            return RegistrationProcessing(MVC.Account.Views.Registration.Step5_Finish);
        }

        [RecaptchaControlMvc.CaptchaValidator]
        [HttpPost]
        private ActionResult Step4_reCaptchaView(RegistrationAccoutStep4Model model, bool captchaValid, string captchaErrorMessage)
        {
            if (!captchaValid)
                return View(MVC.Account.Views.Registration.Step4_reCaptchaView, model);

            var regData = Session[CURRENT_REGISTRATION_MODEL] as RegistrationModel;
            var accountModel = new AccountModel
            {
                FirstName = regData.Step1.Username,
                AgreedToTermsDate = true
            };

            AccountDomain accountDomain = Mapper.Map<AccountDomain>(accountModel);

            ResultServiceOperation<AccountDomain> rez = _аccountService.Save(accountDomain);

            if (rez.ISSuccessfulOperation)
            {
                foreach (var er in rez.Errors)
                    ModelState.AddModelError(er.Key, er.Value);

                return RegistrationProcessing(MVC.Account.Views.Registration.Step4_reCaptchaView);
            }

            return RegistrationProcessing(MVC.Account.Views.Registration.Step5_Finish);
        }

      
        #endregion

        public virtual ActionResult GetAllContacts()
        {
            var listAccount = _аccountService.GetAll();
            List<AccountModel> listModel = Mapper.Map<List<AccountDomain>, List<AccountModel>>(listAccount.Data);
            return PartialView(listModel);
        }
    }
}
