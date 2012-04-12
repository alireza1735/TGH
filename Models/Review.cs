using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Review
    {
        [ScaffoldColumn(false)]
        public int ReviewID { get; set; }

        [DisplayName("Product")]
        public int ProductID { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage="Description Required")]
        public string Description { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime TimeCreated { get; set; }


        public virtual Product Product { get; set; }
    }
}
