using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class UserController : Controller
    {
        UserBs user;
        public UserController()
        {
            user = new UserBs();
        }
        // GET: Common/User
        public ActionResult Index(string SortBy, string SortOrder, int PageNumber = 0)
        {
            ViewBag.CurrentPage = PageNumber;
            ViewBag.SortBy = SortBy;
            ViewBag.SortOrder = SortOrder;
            var result = GetUsers(SortBy, SortOrder);
            ViewBag.PageCount = Math.Ceiling(result.Count() / 10d);
            result = result.Skip((PageNumber - 1) * 10).Take(10);
            return View(result);
        }
        private IEnumerable<tbl_User> GetUsers(string SortBy, string SortOrder)
        {
            var result = user.GetAll();
            switch (SortBy)
            {
                case "UserId":
                    {
                        switch (SortOrder)
                        {
                            case "ASC":
                                result = result.OrderBy(u => u.UserId);
                                break;
                            case "DESC":
                                result = result.OrderByDescending(u => u.UserId);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "UserEmail":
                    {
                        switch (SortOrder)
                        {
                            case "ASC":
                                result = result.OrderBy(u => u.UserEmail);
                                break;
                            case "DESC":
                                result = result.OrderByDescending(u => u.UserEmail);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "Role":
                    {
                        switch (SortOrder)
                        {
                            case "ASC":
                                result = result.OrderBy(u => u.Role);
                                break;
                            case "DESC":
                                result = result.OrderByDescending(u => u.Role);
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