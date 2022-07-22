using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storepos.Transaksi.ViewModel
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        public string IDBarang { get; set; }
        public string NamaBarang { get; set; }
        public string KodeBarang { get; set; }
        public int JumlahStock { get; set; }
        public decimal HargaBarang { get; set; }
        public System.DateTime Tanggal { get; set; }
    }
}