using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Models
{
    public class AccessControl
    {
        public int AccessControlID { get; set; }
        public string UserName { get; set; }
        [DisplayName("قیمت همکار")]
        public bool Fellow { get; set; }
        [DisplayName("خرید اعتباری")]
        public bool CreditBuy { get; set; }
        [DisplayName("امکان آپلود")]
        public bool Upload { get; set; }

    }
}
