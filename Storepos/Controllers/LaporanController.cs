﻿using Storepos.Entitites;
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
    }
}