using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SNet.Web.Models.Account
{
    public class RegistrationModel
    {
        public RegistrationModel()
        {
            Step1 = new RegistrationAccoutStep1Model();
            Step2 = new RegistrationAccoutStep2Model();
            Step3 = new RegistrationAccoutStep3Model();
            Step4 = new RegistrationAccoutStep4Model();
        }

        public RegistrationAccoutStep1Model Step1 { get; set; }
        public RegistrationAccoutStep2Model Step2 { get; set; }
        public RegistrationAccoutStep3Model Step3 { get; set; }
        public RegistrationAccoutStep4Model Step4 { get; set; }
     }
}