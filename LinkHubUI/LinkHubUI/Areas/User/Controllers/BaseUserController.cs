﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    [AllowAnonymous]
    public class BaseUserController : Controller
    {
        protected UserAreaBs userAreaBs;

        public BaseUserController()
        {
            userAreaBs = new UserAreaBs();
        }
    }
}