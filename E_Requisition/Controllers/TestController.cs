using E_Requisition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Requisition.Controllers
{
    public class TestController : Controller
    {
        private ExcelExportEntities1 db = new ExcelExportEntities1();

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestProfile()
        {
            User u = db.User.FirstOrDefault(x => x.name == "sysop");
            var profiles = u.User_Profile.Select(p => p.type).ToList();
            return Json(String.Join(", ", profiles.ToArray()), JsonRequestBehavior.AllowGet);
        }
    }
}