using Storepos.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storepos.Transaksi.Repositories
{
    public class PaymentTypeRepository
    {
        private posEntities objRestaurantDbEntities;
        public PaymentTypeRepository()
        {
            objRestaurantDbEntities = new posEntities();
        }
        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestaurantDbEntities.PaymentTypes
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentType1,
                                      Value = obj.PaymentTypeId.ToString(),
                                      Selected = true
                                  }).ToList();

            return objSelectListItems;


        }
    }
}