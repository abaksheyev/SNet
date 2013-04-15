using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNet.Interfaces;
using SNet.Repositories.DataModel;

namespace SNet.Repositories
{
    public class AccountRepository : BaseRepository<DbContext, Account>, IAccountRepository
    {
        public AccountRepository() :
            base(new DbContext(@"Data Source=(LocalDb)\v11.0;Initial Catalog=aspnet-SNet.Web-20130315233806;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\aspnet-SNet.Web-20130315233806.mdf"))
        {



        }
    }
}
