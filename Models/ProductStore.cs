using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Models
{
    public class ProductStore
    {
        public int ProductStoreID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int QuantitySelled { get; set; }
        [DisplayName("قیمت خرید")]
        public decimal BuyPrice { get; set; }
        [DisplayName("قیمت فروش")]
        public decimal SellPrice { get; set; }
        [DisplayName("قیمت همکار")]
        public decimal FellowPrice { get; set; }
        public DateTime TimeCreated { get; set; }
        
        public virtual Product Product { get; set; }
    }
}
