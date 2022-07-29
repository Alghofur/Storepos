using Storepos.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LaporanControllers
{
    //[Authorize(Roles = "SuperAdmin")]
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
                List<OrderDetail> empList = db.OrderDetails.ToList<OrderDetail>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpGet]
        //public ActionResult LaporanCreate(int id = 0)
        //{
        //    return View(new Laporann());
        //}
        //[HttpPost]
        //public ActionResult LaporanCreate(Laporann emp)
        //{
        //    using (posEntities db = new posEntities())
        //    {
        //        db.Laporanns.Add(emp);
        //        db.SaveChanges();
        //        return Json(new { success = true, messeage = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
        //    }

        //}
    }
}