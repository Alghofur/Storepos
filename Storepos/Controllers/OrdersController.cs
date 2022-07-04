using Storepos.BusinessLogic.IService;
using Storepos.BusinessLogic.serviceCls;
using Storepos.Utility.RequestCls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storepos.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        Iorders _order;

        public OrdersController()
        {
            _order = new OrderCls();
        }

        public ActionResult
    }
}