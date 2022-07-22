using Storepos.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storepos.Transaksi.Repositories
{
    public class CustomerRepository
    {
        private posEntities objRestaurantDbEntities;

        public CustomerRepository()
        {
            objRestaurantDbEntities = new posEntities();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestaurantDbEntities.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerId.ToString(),
                                      Selected = true
                                  }).ToList();

            return objSelectListItems;


        }


    }
}