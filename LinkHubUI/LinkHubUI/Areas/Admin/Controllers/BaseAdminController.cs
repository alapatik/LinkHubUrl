﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        protected AdminBs adminBs;
        public BaseAdminController()
        {
            adminBs = new AdminBs();
        }
    }
}