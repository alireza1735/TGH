using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Personel
    {
        public int PersonelID { get; set; }
        public string UserName { get; set; }
        
        public decimal Wage { get; set; }
        public DateTime HireDate { get; set; }
        public string Unit { get; set; }

        public Person PersonelInfo { get; set; }
        public Person ReagentInfo1 { get; set; }
        public Person ReagentInfo2 { get; set; }
    }

}
