using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CartController : Controller
    {
        // GET: Admin/Cart
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index()
        {
            var dao = new OrderDao();
            ViewBag.listOrder = dao.ListOrder();
            return View();
        }
    }
}