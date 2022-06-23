using Storepos.Entitites;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Storepos.Controllers
{
    public class BarangController : Controller
    {
        // GET: Barang
        public ActionResult Index()
        {
            List<Barang> r;
            using (var s = new posEntities())
            {
                r = s.Barang.ToList();
            }
            return View(r);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var barangmodel = new Barang();
            TryUpdateModel(barangmodel);

            using (var s = new posEntities())
            {
                s.Barang.Add(barangmodel);
                s.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(string idbarang)
        {
            var barangmodel = new Barang();
            TryUpdateModel(barangmodel);
            using (var s = new posEntities())
            {
                barangmodel = s.Barang.Where(x => x.IDBarang == idbarang).FirstOrDefault();
            }
            return View(barangmodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(string idbarang)
        {
            var barangmodel = new Barang();
            TryUpdateModel(barangmodel);
            using (var s = new posEntities())
            {
                var m = s.Barang.Where(x => x.IDBarang == idbarang).FirstOrDefault();
                TryUpdateModel(m);
                s.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details (string idbarang)
        {
            var barangmodel = new Barang();
            TryUpdateModel(barangmodel);
            using (var s = new posEntities())
            {
                barangmodel = s.Barang.FirstOrDefault(x => x.IDBarang == idbarang);
            }
            return View(barangmodel);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(string idbarang)
        {
            var barangmodel = new Barang();
            TryUpdateModel(barangmodel);
            using (var s = new posEntities())
            {
                barangmodel = s.Barang.FirstOrDefault(x => x.IDBarang == idbarang);
            }
            return View(barangmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(string idbarang)
        {
            var barangmodel = new Barang();
            TryUpdateModel(barangmodel);
            using (var s = new posEntities())
            {
                var m = s.Barang.Remove(s.Barang.FirstOrDefault(x => x.IDBarang == idbarang));
                TryUpdateModel(m);
                s.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult GeneratePDF()
        {

            return new Rotativa.ActionAsPdf("Index");
        }
    }
}