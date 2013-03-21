using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNet.Web.Helpers
{
    public static class MvcHtmlStringHelper
    {
        public static MvcHtmlString GenerateCaptcha(this HtmlHelper htmlHelper)
        {
            var html = Recaptcha.RecaptchaControlMvc.GenerateCaptcha(htmlHelper);
            return MvcHtmlString.Create(html);
        }
    }
}