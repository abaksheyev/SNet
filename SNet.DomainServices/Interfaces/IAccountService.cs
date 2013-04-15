using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNet.Common.DomainModels;
using SNet.Common;

namespace SNet.DomainServices.Interfaces
{
    public interface IAccountService
    {

        ResultServiceOperation<AccountDomain> GetAll();

        ResultServiceOperation<AccountDomain> Save(AccountDomain entity);

        ResultServiceOperation<AccountDomain> Activate(AccountDomain entity);

        ResultServiceOperation<AccountDomain> Delete(AccountDomain entity);
    }
}
