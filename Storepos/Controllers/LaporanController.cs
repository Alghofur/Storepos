using Storepos.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storepos.Controllers
{
    public class LaporanController : Controller
    {
        // GET: Laporan
        [Authorize(Roles = "SuperAdmin, Manager")]
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetData()
        {
            using (posEntities db = new posEntities())
            {
                var empList = db.OrderDetails.ToList<OrderDetail>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        //public ActionResult Delete(string[] IDLaporans)
        //{
        //    using (posEntities db = new posEntities())
        //    {
        //        foreach (string IDLaporan in IDLaporans)
        //        {
        //            Laporann obj = db.Laporanns.Find(IDLaporan);
        //            db.Laporanns.Remove(obj);
        //        }
        //        db.SaveChanges();
        //        return Json("All the customers deleted successfully!");
        //    }
        //}

        //public ActionResult DeleteLap(string[] IDLaporans)
        //{
        //    int[] getid = null;
        //    if (IDLaporans != null)
        //    {
        //        getid = new int[IDLaporans.Length];
        //        int j = 0;
        //        foreach(string i in IDLaporans)
        //        {
        //            int.TryParse(i, out getid[j++]);
        //        }

        //        List<Laporann> getIDLaporans = new List<Laporann>();
        //        posEntities sd = new posEntities();
        //        getIDLaporans = sd.Laporanns.Where(x => getid.Contains(x.IDLaporan)).ToList();
        //        foreach(var s in getIDLaporans)
        //        {
        //            sd.Laporanns.Remove(s);
        //        }
        //        sd.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}