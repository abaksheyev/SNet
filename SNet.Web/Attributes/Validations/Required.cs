using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SNet.Common;

namespace SNet.Web.Attributes.Validations
{
    public class RequiredLocalized : ValidationAttribute
    {
        public RequiredLocalized()
        {
            ErrorMessage = Settings.Instance.GetLocalizedText("Filed_IsRequired");
        }
    }
}