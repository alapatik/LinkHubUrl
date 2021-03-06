﻿using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        
        // GET: Seurity/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignIn(tbl_User user)
        {
            if (Membership.ValidateUser(user.UserEmail, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                return RedirectToAction("Index", "Home", new { area = "Common" });
            }
            else
            {
                TempData["Msg"] = "Login Failed.";
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}