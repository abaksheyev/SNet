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
    public class AccountRepository : 
        BaseRepository<DbContext, Account>, 
        IAccountRepository
    {
        public AccountRepository(DbContext context)
            : base(context)
        {
        }
    }
}
