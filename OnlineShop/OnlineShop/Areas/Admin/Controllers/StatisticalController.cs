using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class StatisticalController : BaseController
    {
        // GET: Admin/Statistical
        public ActionResult Index()
        {
            var dao = new StatisticalDao();
            ViewBag.listSta = dao.listStatistical();
            return View();
        }
        public ActionResult Search(string keyword)
        {
            int totalRecord = 0;
            var model = new StatisticalDao().Search(keyword, ref totalRecord);
            ViewBag.Total = totalRecord;
            ViewBag.Keyword = keyword;
            return View(model);
        }
    }
}