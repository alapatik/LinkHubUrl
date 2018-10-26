using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="A")]
    public class CategoryController : BaseAdminController
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(tbl_Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    adminBs.categoryBs.Insert(category);
                    TempData["Msg"] = "Created successfully";
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = "Create failed. " + ex.Message;
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}