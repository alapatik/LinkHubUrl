using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BrowseURLController : BaseCommonController
    {  
        // GET: Common/BrowseURL
        public ActionResult Index(string SortOrder, string SortBy, string PageNumber)
        {
            ViewBag.SortOrder = string.IsNullOrWhiteSpace(SortOrder) ? "ASC" : SortOrder;
            ViewBag.SortBy = string.IsNullOrWhiteSpace(SortBy) ? "Title" : SortBy;
            int pageNumber = 1;
            if (!int.TryParse(PageNumber, out pageNumber))
                pageNumber = 1;
            ViewBag.PageNumber = pageNumber;
            var urls = PrepareQuery(SortBy, SortOrder);
            ViewBag.PageCount = Math.Ceiling(urls.Count() / 10d);
            urls = urls.Skip((pageNumber - 1) * 10).Take(10);
            return View(urls);
        }
        private IEnumerable<BOL.tbl_Url> PrepareQuery(string sortBy, string sortOrder)
        {
            IEnumerable<BOL.tbl_Url> urls = commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A"));
            switch (sortBy)
            {
                case "Title":
                    urls = sortOrder == "ASC" ?
                        commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderBy(u => u.UrlTitle) :
                        commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderByDescending(u => u.UrlTitle);
                    break;
                case "Url":
                    urls = sortOrder == "ASC" ?
                    commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderBy(u => u.Url) :
                    commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderByDescending(u => u.Url);
                    break;
                case "UrlDesc":
                    urls = sortOrder == "ASC" ?
                    commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderBy(u => u.UrlDesc):
                    commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderByDescending(u => u.UrlDesc);
                    break;
                case "IsApproved":
                    urls = sortOrder == "ASC" ?
                    commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderBy(u => u.IsApproved):
                    commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderByDescending(u => u.IsApproved);
                    break;
                case "CategoryName":
                    urls = sortOrder == "ASC" ?
                    commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderBy(u => u.tbl_Category.CategoryName):
                    commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderByDescending(u => u.tbl_Category.CategoryName);
                    break;
                case "UserEmail":
                    urls = sortOrder == "ASC" ?
                    commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderBy(u => u.tbl_User.UserEmail):
                    commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderByDescending(u => u.tbl_User.UserEmail);
                    break;
                default:
                    urls = commonBs.urlBs.GetAll().Where(u => u.IsApproved.Equals("A")).OrderBy(u => u.UrlTitle);
                    break;
            }
            return urls;
        }
    }
}