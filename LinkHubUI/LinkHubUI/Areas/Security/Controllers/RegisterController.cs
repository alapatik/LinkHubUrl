﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    public class RegisterController : BaseSecurityController
    {
        // GET: Seurity/Register
        public ActionResult Index()
        {
            return View();
        }
    }
}