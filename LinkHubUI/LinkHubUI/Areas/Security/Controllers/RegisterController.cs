using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        // GET: Seurity/Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Submit(tbl_User user)
        {
            if(ModelState.IsValid)
            {
                user.Role = "U";
                adminBs.userBs.Insert(user);
                TempData["Msg"] = "Created Successfully.";
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "Create Failed.";
            return View("Index");
        }
    }
}