﻿using SNet.DomainServices.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNet.Web.Controllers
{
    public partial class BaseController : Controller
    {
        public BaseController()
        {
            UIMapping.Configure();
        }
    }
}
