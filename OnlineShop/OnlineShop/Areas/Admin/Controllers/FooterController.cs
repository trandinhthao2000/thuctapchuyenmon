using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class FooterController : Controller
    {
        // GET: Admin/Footer
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index()
        {
            return View();
        }
    }
}