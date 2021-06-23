using Model.Dao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class StatisticalController : BaseController
    {
        // GET: Admin/Statistical
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index()
        {
            var dao = new StatisticalDao();
            ViewBag.listthongke = dao.listthongke();
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
        [HttpGet]
        public ActionResult Export()
        {
            var stream = new StatisticalDao().CreateExcelFile();
            var buffer = stream as MemoryStream;

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename" + "Excel.xlsx");
            
            Response.BinaryWrite(buffer.ToArray());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");
        }
    }
}