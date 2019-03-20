using E_Requisition.Extensions;
using E_Requisition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Requisition.Controllers
{
    public class HomeController : Controller
    {
        LogonStatus _LogonStatus = new LogonStatus(); //<--先NEW出LogonStatus物件
        private ExcelExportEntities1 db = new ExcelExportEntities1();
        private readonly string salt = "Hello world!";

        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Logon()
        {
            if (_LogonStatus.isSigned())
            {
                return Content("PASS");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logon(FormCollection LogonCollection)
        {

            var UserName = LogonCollection["name"].ifNulltoEmpty();
            var Password = LogonCollection["password"].ifNulltoEmpty();

            // 登入的密碼（以 SHA1 加密）
            //var PasswordSHA = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");

            //這一條是去資料庫抓取輸入的帳號密碼的方法請自行實做
            //var myAcc = account.GetSingleAccount(acc, Password);

            Password = FormsAuthentication.HashPasswordForStoringInConfigFile(salt + Password, "MD5");

            //做一個假的範例用
            var user = db.User.FirstOrDefault(u => u.name == UserName && u.password == Password);

            if (user == null)
            {
                ModelState.AddModelError("", "請輸入正確的帳號或密碼!");
                return View();
            }

            // 登入時清空所有 Session 資料
            Session.RemoveAll();

            var profiles = user.User_Profile.Select(p => p.type).ToList();

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
            user.name,//你想要存放在 User.Identy.Name 的值，通常是使用者帳號
            DateTime.Now,
            DateTime.Now.AddMinutes(30),
            false,//將管理者登入的 Cookie 設定成 Session Cookie
            String.Join(", ", profiles.ToArray()),//userdata看你想存放啥
            FormsAuthentication.FormsCookiePath);

            string encTicket = FormsAuthentication.Encrypt(ticket);

            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            return RedirectToAction("TestIsLogon", "Home");
            //return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return View("Logon");
        }

        [Authorize]
        public ActionResult TestIsLogon()
        {
            ViewData["IsAuthenticated"] = "未登入";
            if (_LogonStatus.isSigned())
            {
                ViewData["IsAuthenticated"] = "已登入";
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}