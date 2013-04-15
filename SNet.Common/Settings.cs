using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Hosting;
using System.IO;

using SNet.Common.Enums;

namespace SNet.Common
{
    public class Settings : Singleton<Settings>
    {
        public string Them
        {
            get { return "b"; }
        }

        public UILanguage CurrentUiLanguage
        {
            get { return UILanguage.Russian; }
        }

        /// <summary>
        /// Forbit direct create setting
        /// </summary>
        private Settings()
        {
           
        }

        public string RootPath
        {
            get { return HostingEnvironment.MapPath("~/"); }
        }

        public string GetLocalizedText(string keyField)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();


            if (CurrentUiLanguage == UILanguage.Russian)
            {
                var path = Path.Combine(Settings.Instance.RootPath, @"..\SNet.Common\Resources\Resources.ru.resx");

                // Enumerate the resources in the file.
                ResXResourceReader rsxr = new ResXResourceReader(path);

              
                // Create an IDictionaryEnumerator to iterate through the resources.
                IDictionaryEnumerator id = rsxr.GetEnumerator();


                // Iterate through the resources and display the contents
                foreach (DictionaryEntry d in rsxr)
                {
                    values.Add(d.Key.ToString(), d.Value.ToString());
                }

                return values[keyField] as string;
            }
            else if (CurrentUiLanguage == UILanguage.En)
            {
                var rm = new ResourceManager("SNet.Common.Resources.ru", Assembly.GetAssembly(typeof(Settings)));
                return rm.GetObject(keyField) as string;
            }
            else
            {
                return string.Format("{0} ???", keyField);
            }

        }
    }

    internal enum Thems
    {
            
    }
}
