using Storepos.Entitites;
using Storepos.Transaksi.Repositories;
using Storepos.Transaksi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Storepos.Controllers
{
    public class TransaksiController : Controller
    {
        private posEntities objRestaurantDbEntities;

        public TransaksiController()
        {
            objRestaurantDbEntities = new posEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository objcustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objpaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                    (objcustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objpaymentTypeRepository.GetAllPaymentType());
            return View(objMultipleModels);
        }

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objRestaurantDbEntities.BARANG___.Single(model => model.ID == itemId).HargaBarang;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Fajar(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewModel);
            return Json(data: "your Order has been Successfully Created", JsonRequestBehavior.AllowGet);
        }
    }
}