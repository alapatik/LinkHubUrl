using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    public class URLController : BaseUserController
    {
        LinkHubDbEntities db;
        public URLController()
        {
            db = new LinkHubDbEntities();
        }
        // GET: User/URL
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(db.tbl_User, "UserId", "UserEmail");
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Url myUrl)
        {
            ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(db.tbl_User, "UserId", "UserEmail");
            if (ModelState.IsValid)
            {
                try
                {
                    userAreaBs.urlBs.Insert(myUrl);
                    TempData["Msg"] = "Url created successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = "Create URL failed. " + ex.Message;
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
            
        }
    }
}