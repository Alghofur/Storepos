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
        posEntities Dc = new posEntities();

        // GET: Barang
        public ActionResult Laporan()
        {
            return View(Dc.OrderDetails.ToList());
        }

        public ActionResult GetData()
        {
            using (posEntities db = new posEntities())
            {
                List<OrderDetail> empList = db.OrderDetails.ToList();
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

        //}h
    }
}