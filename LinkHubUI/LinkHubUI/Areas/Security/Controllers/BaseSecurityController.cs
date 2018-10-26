using BLL;
using LinkHubUI.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    public class BaseSecurityController : BaseAdminController
    {
        protected SecurityBs securityBs;
        public BaseSecurityController()
        {
            securityBs = new SecurityBs();
        }
    }
}