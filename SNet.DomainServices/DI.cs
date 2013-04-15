using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNet.Common;
using SNet.Repositories;
using SNet.Interfaces;
using System.Data.Entity;

namespace SNet.DomainServices
{
    public static class DIDomainServices
    {

        public static void Cofigure(StructureMap.IInitializationExpression x)
        {
            x.For<IAccountRepository>().HttpContextScoped().Use<AccountRepository>();
        }
    }
}
