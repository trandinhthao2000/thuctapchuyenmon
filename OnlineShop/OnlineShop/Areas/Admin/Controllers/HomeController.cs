using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            
            ViewBag.countdoanhthu = new StatisticalDao().countdoanhthu();
            ViewBag.countloinhuan = new StatisticalDao().countloinhuan();
            ViewBag.counttask = new OrderDao().counttask();
            ViewBag.countfeedback = new FeedbackDao().countfeedback();
            ViewBag.doanhthu4 = new StatisticalDao().doanhthu4();
            ViewBag.loinhuan4 = new StatisticalDao().loinhuan4();
            ViewBag.doanhthu5 = new StatisticalDao().doanhthu5();
            ViewBag.loinhuan5 = new StatisticalDao().loinhuan5 ();
            ViewBag.doanhthu6 = new StatisticalDao().doanhthu6();
            ViewBag.loinhuan6 = new StatisticalDao().loinhuan6();
            ViewBag.listthongke = new StatisticalDao().listthongke();
            return View();
        }
    }
}