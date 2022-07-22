using Storepos.Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storepos.Controllers
{
    public class BarangController : Controller
    {
        posEntities Dc = new posEntities();

        // GET: Barang
        public ActionResult Index()
        {
            return View(Dc.BARANG___.ToList());
        }

        public ActionResult Create(int id = 0)
        {
            BARANG___ emp = new BARANG___();
            var barang = Dc.BARANG___.OrderByDescending(c => c.ID).FirstOrDefault();
            if (id != 0)
            {
                emp = Dc.BARANG___.Where(x => x.ID == id).FirstOrDefault<BARANG___>();
            }
            else if (barang == null)
            {
                emp.IDBarang = "EKASA ID001";
            }
            else
            {
                emp.IDBarang = "EKASA ID" + (Convert.ToInt32(barang.IDBarang.Substring(9, barang.IDBarang.Length - 9)) + 1).ToString("D3");
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Create(BARANG___ R)
        {
            using (Dc)
            {
                Dc.BARANG___.Add(R);
                Dc.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(Dc.BARANG___.Find(id));
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult delete(int id)
        {
            BARANG___ Reg = Dc.BARANG___.Find(id);
            Dc.BARANG___.Remove(Reg);
            Dc.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(Dc.BARANG___.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(BARANG___ R)
        {
            Dc.Entry(R).State = EntityState.Modified;
            Dc.SaveChanges();
            return RedirectToAction("Index");
        }

         public ActionResult Details(int id)
        {
            return View(Dc.BARANG___.Find(id));
        }


    }
}