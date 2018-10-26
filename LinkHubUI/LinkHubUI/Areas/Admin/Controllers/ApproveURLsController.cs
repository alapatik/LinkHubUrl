using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="A")]
    public class ApproveURLsController : BaseAdminController
    {
        // GET: Admin/ApproveURLs
        public ActionResult Index(string filterBy = "", int pageNumber =1)
        {
            var urlCollection = adminBs.urlBs.GetAll();
            if(!string.IsNullOrWhiteSpace(filterBy))
            {
                urlCollection = urlCollection.Where(u => u.IsApproved.ToLower().Equals(filterBy));
            }
            ViewBag.PageNumber = pageNumber;
            ViewBag.FilterBy = filterBy;
            ViewBag.PageCount = Math.Ceiling(urlCollection.Count() / 10d);
            urlCollection = urlCollection.Skip(pageNumber - 1).Take(10);
            return View(urlCollection);
        }
        public ActionResult ChangeUrlStatus(int id, string status, string filterBy, int pageNumber)
        {
            var url = adminBs.urlBs.GetAll().FirstOrDefault(u => u.UrlId == id);
            if(url != null)
            {
                url.IsApproved = status;
                adminBs.urlBs.Update(url);
            }
            return RedirectToAction("Index", new { filterBy, pageNumber });
        }
    }
}