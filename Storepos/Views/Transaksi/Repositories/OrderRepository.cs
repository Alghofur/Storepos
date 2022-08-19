using Storepos.Entitites;
using Storepos.Transaksi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storepos.Transaksi.Repositories
{
    public class OrderRepository
    {
        private posEntities objRestaurantDbEntities;
        public OrderRepository()
        {
            objRestaurantDbEntities = new posEntities();
        }

        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = String.Format("{0:ddmmmyyyghmmdd}", DateTime.Now);
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
            objRestaurantDbEntities.Orders.Add(objOrder);
            objRestaurantDbEntities.SaveChanges();
            int OrderId = objOrder.OrderId;

            foreach (var item in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.OrderId = OrderId;
                objOrderDetail.Discount = item.ItemId;
                objOrderDetail.ItemName = item.ItemName;
                objOrderDetail.Total = item.Total;
                objOrderDetail.UnitPrice = item.UnitPrice;
                objOrderDetail.Quantity = item.Quantity;
                objRestaurantDbEntities.OrderDetails.Add(objOrderDetail);
                objRestaurantDbEntities.SaveChanges();

                Transaction objtTransaction = new Transaction();
                objtTransaction.ItemId = item.ItemId;
                objtTransaction.Quantity = (-1) * item.Quantity;
                objtTransaction.Transaction1 = DateTime.Now;
                objtTransaction.TypeId = 2;
                objRestaurantDbEntities.Transactions.Add(objtTransaction);
                objRestaurantDbEntities.SaveChanges();
            }

            return true;
        }

    }
}