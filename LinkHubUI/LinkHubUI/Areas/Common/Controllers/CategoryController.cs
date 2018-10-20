using BLL;
using BOL;
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
        public ActionResult Index(string SortBy = "CategoryID", string SortOrder= "ASC", int PageNumber = 1)
        {
            var result = GetAll(SortBy, SortOrder);
            ViewBag.PageCount = Math.Ceiling(result.Count() / 10d);
            ViewBag.CurrentPage = PageNumber;
            ViewBag.SortBy = SortBy;
            ViewBag.SortOrder = SortOrder;
            result = result.Skip((PageNumber - 1) * 10).Take(10);
            return View(result);
        }
        private IEnumerable<tbl_Category> GetAll(string SortBy, string SortOrder)
        {
            var result = categoryBs.GetAll();
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