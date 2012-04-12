using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{    
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [DisplayName("رسته")]
        [Required(ErrorMessage = "یک رسته را انتخاب کنید")]
        public int CategorieID { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Description { get; set; }

        public string Brand { get; set; }
        
        public int Rating { get; set; }
        public int RatingNumber { get; set; }
        public bool Enabled { get; set; }

        [ScaffoldColumn(false)]
        [Bindable(false)]
        public byte[] Image { get; set; }



        public List<Review> Reviews { get; set; }
        public List<ProductStore> ProductStores { get; set; }

        public virtual Categorie Categorie { get; set; }
        public virtual List<OrderDetail> OrderDetail { get; set; }
    }
}
