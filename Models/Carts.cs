using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Models
{
    public class Carts
    {
        [Key]
        public int ShoppingID { get; set; }

        [ScaffoldColumn(false)]
        public string CartID { get; set; }

        [DisplayName("Product")]
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime TimeCreated { get; set; }


        public virtual Product Product { get; set; }
    }
}
