﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNet.Repositories;

namespace SNet.Interfaces
{
    public interface IAccountRepository :
        IBaseRepository<Account> 
    {
    }
}
