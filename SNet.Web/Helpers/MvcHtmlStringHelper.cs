using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using SNet.Common;

namespace SNet.Web.Helpers
{
    public static class MvcHtmlStringHelper
    {
        public static MvcHtmlString GenerateCaptcha(this HtmlHelper htmlHelper)
        {
            var html = Recaptcha.RecaptchaControlMvc.GenerateCaptcha(htmlHelper);
            return MvcHtmlString.Create(html);
        }

        #region -- Localized Label --



        public static MvcHtmlString LocalizedLabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                         Expression<Func<TModel, TProperty>> expression,
                                                                         IDictionary<string, object> htmlAttributes =
                                                                             null)
        {
            string inputName = ExpressionHelper.GetExpressionText(expression);
            string labelText = Settings.Instance.GetLocalizedText(inputName);

            return htmlHelper.Label(inputName, labelText, htmlAttributes);
        }

        #endregion
    }
}