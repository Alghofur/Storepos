using Storepos.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LaporanControllers
{
    public class LaporanController : Controller
    {
        // GET: Laporan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (posEntities db = new posEntities())
            {
                List<Laporann> empList = db.Laporann.ToList<Laporann>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult LaporanCreate(int id = 0)
        {
            return View(new Laporann());
        }
        [HttpPost]
        public ActionResult LaporanCreate(Laporann emp)
        {
            using (posEntities db = new posEntities())
            {
                db.Laporann.Add(emp);
                db.SaveChanges();
                return Json(new { success = true, messeage = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}