using Storepos.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storepos.Transaksi.Repositories
{
    public class ItemRepository
    {
        private posEntities objRestaurantDbEntities;

        public ItemRepository()
        {
            objRestaurantDbEntities = new posEntities();
        }
        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestaurantDbEntities.BARANG___
                                  select new SelectListItem()
                                  {
                                      Text = obj.NamaBarang,
                                      Value = obj.ID.ToString(),
                                      Selected = false
                                  }).ToList();

            return objSelectListItems;


        }

    }
}