using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class CategoryController : Controller
    {
        CategoryBs categoryBs;
        public CategoryController()
        {
            categoryBs = new CategoryBs();
        }
        // GET: Common/Category
        public ActionResult Index()
        {
            var result = categoryBs.GetAll();
            return View(result);
        }
    }
}