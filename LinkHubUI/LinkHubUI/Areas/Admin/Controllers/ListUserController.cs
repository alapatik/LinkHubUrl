using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="A")]
    public class ListUserController : BaseAdminController
    {
        // GET: Admin/ListUser
        public ActionResult Index()
        {
            var users = adminBs.userBs.GetAll();
            return View(users);
        }
    }
}