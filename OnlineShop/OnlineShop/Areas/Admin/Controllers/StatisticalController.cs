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
            // Gọi lại hàm để tạo file excel
            var stream = new StatisticalDao().CreateExcelFile();
            // Tạo buffer memory strean để hứng file excel
            var buffer = stream as MemoryStream;

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename" + "Excel.xlsx");
            // Lưu file excel của chúng ta như 1 mảng byte để trả về response
            Response.BinaryWrite(buffer.ToArray());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");
        }
    }
}