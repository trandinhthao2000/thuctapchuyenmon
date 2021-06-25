using Model.Dao;
using Model.EF;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.GroupID = user.GroupID;
                    var listCredentials = dao.GetListCredential(model.UserName);

                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài Khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập ");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            User user = (User)Session["changepass"];
            var us = new UserDao().ViewDetail((int)user.ID);
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(User user)
        {
            User user1 = (User)Session["changepass"];
            user.ID = user1.ID;
            var dao = new UserDao();
            if (!string.IsNullOrEmpty(user.Password))
            {
                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;
            }
            var result = dao.ForgotPass(user);
            return View("Index");
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            LoginModel login = new LoginModel();
            login.Password = "1111";
            login.UserName = "1111";
            ViewBag.Message = "";
            return View(login);
        }
        [HttpPost]
        public ActionResult ForgotPassword(LoginModel model)
        {
            var dao = new UserDao();
            if (model.Email != null)
            {
                if (new OnlineShopDbContext().Users.SingleOrDefault(x => x.Email.Equals(model.Email)) != null)
                {
                    Session["changepass"] = new OnlineShopDbContext().Users.SingleOrDefault(x => x.Email.Equals(model.Email));
                    new MailHelper().SendMail(model.Email, "Xác nhận mật khẩu", "Nhấn vào dường dẫn để đổi mật khẩu <a href = https://localhost:44349/Admin/Login/ChangePassword >Xác Nhận</a> ");
                    ViewBag.Message = "Vui lòng kiểm tra mail của bạn";
                }
                else
                {
                    ModelState.AddModelError("", "Mail bạn nhập không tồn tại!!");
                    ViewBag.Message = "";
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập email!!");
                ViewBag.Message = "";
            }

            return View();
        }
        public class MailHelper
        {
            public void SendMail(string toEmailAddress, string subject, string content)
            {
                var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
                var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayNameXacNhanTaiKhoan"].ToString();
                var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
                var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

                bool enabledSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());

                string body = content;
                MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;

                var client = new SmtpClient();
                client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
                client.Host = smtpHost;
                client.EnableSsl = enabledSsl;
                client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
                client.Send(message);
            }
        }
    }
}