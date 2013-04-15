using SNet.Common.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNet.Web.Models.Account
{
    public class AccountModel : AccountDomain
    {
        public string FillName
        {
            get { return FirstName + ' ' + LastName; }
        }
    }
}