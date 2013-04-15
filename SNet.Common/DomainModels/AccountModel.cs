using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNet.Common.DomainModels
{
    public class AccountDomain
    {
        public int Id { get;set;}

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Age { get; set; }

        public DateTime Birthday { get; set; }

        public bool AgreedToTermsDate { get; set; }
    }
}
