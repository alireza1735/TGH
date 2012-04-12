using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Models
{
    public class Categorie
    {
        [ScaffoldColumn(false)]
        public int CategorieID { get; set; }

        [Required(ErrorMessage="Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }


        public List<Product> Products { get; set; }
    }
}
