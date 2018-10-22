using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ListCategoryController : BaseAdminController
    {
        // GET: Common/Category
        public ActionResult Index(string SortBy = "CategoryID", string SortOrder = "ASC", int PageNumber = 1)
        {
            var result = GetAll(SortBy, SortOrder);
            ViewBag.PageCount = Math.Ceiling(result.Count() / 10d);
            ViewBag.CurrentPage = PageNumber;
            ViewBag.SortBy = SortBy;
            ViewBag.SortOrder = SortOrder;
            result = result.Skip((PageNumber - 1) * 10).Take(10);
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(string SortBy, string SortOrder, int CurrentPage, int CategoryId)
        {
            try
            {
                adminBs.categoryBs.DeleteById(CategoryId);
                TempData["Msg"] = "Delete successful.";
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Delete failed. " + ex.Message;
            }
            return RedirectToAction("Index", new { SortBy, SortOrder, CurrentPage });
        }
        private IEnumerable<tbl_Category> GetAll(string SortBy, string SortOrder)
        {
            var result = adminBs.categoryBs.GetAll();
            switch (SortBy)
            {
                case "CategoryId":
                    {
                        switch (SortOrder)
                        {
                            case "ASC":
                                result = result.OrderBy(c => c.CategoryId);
                                break;
                            case "DESC":
                                result = result.OrderByDescending(c => c.CategoryId);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "CategoryName":
                    {
                        switch (SortOrder)
                        {
                            case "ASC":
                                result = result.OrderBy(c => c.CategoryName);
                                break;
                            case "DESC":
                                result = result.OrderByDescending(c => c.CategoryName);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}