using Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new FeedbackDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedbackDao();
                long id = dao.Insert(feedback);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "Feedback");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new FeedbackDao().Delete(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new FeedbackDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        public ActionResult Reply(int id)
        {
            var feedback = new FeedbackDao().ViewDetail(id);
            return View(feedback);
        }
        [HttpPost]
        public ActionResult Reply(Feedback feedback, string name, string reply, string email)
        {
            if (ModelState.IsValid)
            {
                feedback.Name = name;
                feedback.Reply = reply;
                feedback.Email = email;
                var rep = new FeedbackDao().Reply(feedback);
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/template/reply.html"));
                content = content.Replace("{{CustomerName}}", name);
                content = content.Replace("{{Reply}}", reply);
                new MailHelper().SendMail(email, "Phản hồi từ cửa hàng", content);
            }
            return View("Reply");
        }


    }
}